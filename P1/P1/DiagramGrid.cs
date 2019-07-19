using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace P1
{
    public class GridScrollViewer
    {
        public ScrollViewer ScrollViewer { get; private set; }
        public Grid Grid { get; private set; }
        public Slider Slider { get; private set; }
        private ScaleTransform ScaleTransform;
        private Point? lastCenterPositionOnTarget;
        private Point? lastMousePositionOnTarget;
        private Point? lastDragPoint;

        public GridScrollViewer(int viewerWidth , int viewerHeight, Thickness viewerMargin, Thickness gridMargin)
        {
            DrawScrollViewer(viewerMargin);
            DrawSlider();
            DrawGrid(gridMargin);
        }

        private void DrawGrid(Thickness gridMargin)
        {
            Grid = new Grid()
            {
                Width = 1000,
                Height = 1000,
                Margin = gridMargin,
                Background = Brushes.LightBlue,
            };
            ScaleTransform = new ScaleTransform(2, 2, 10, 10);
            Grid.LayoutTransform = ScaleTransform;
            ScrollViewer.Content = Grid;
        }

        private void DrawSlider()
        {
            Slider = new Slider()
            {
                Name = "Zoom",
                Width = 700,
                Height = 30,
                Minimum = 1,
                Maximum = 100,
                Background = Brushes.Red,
                VerticalAlignment = VerticalAlignment.Bottom,
                Orientation = Orientation.Horizontal
            };
            Slider.ValueChanged += Slider_ValueChanged;
        }

        private void DrawScrollViewer(Thickness viewerMargin)
        {
            ScrollViewer = new ScrollViewer()
            {
                Width = 740,
                Height = 380,
                Margin = viewerMargin,
                Background = Brushes.Gold,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Visible,
            };

            ScrollViewer.ScrollChanged += ScrollViewer_ScrollChanged; ;
            ScrollViewer.MouseLeftButtonUp += ScrollViewer_MouseLeftButtonUp;
            ScrollViewer.PreviewMouseLeftButtonUp += ScrollViewer_MouseLeftButtonUp;
            ScrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
            ScrollViewer.PreviewMouseLeftButtonDown += ScrollViewer_PreviewMouseLeftButtonDown;
            ScrollViewer.MouseMove += ScrollViewer_MouseMove;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScaleTransform.ScaleX = e.NewValue;
            ScaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(ScrollViewer.ViewportWidth,
                                             ScrollViewer.ViewportHeight);
            lastCenterPositionOnTarget = ScrollViewer.TranslatePoint(centerOfViewport, Grid);
        }

        private void ScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (lastDragPoint.HasValue)
            {
                Point posNow = e.GetPosition(ScrollViewer);

                double dX = posNow.X - lastDragPoint.Value.X;
                double dY = posNow.Y - lastDragPoint.Value.Y;

                lastDragPoint = posNow;

                ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - dX);
                ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - dY);
            }
        }

        private void ScrollViewer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var mousePos = e.GetPosition(ScrollViewer);
            if (mousePos.X <= ScrollViewer.ViewportWidth && mousePos.Y <
                ScrollViewer.ViewportHeight) //make sure we still can use the scrollbars
            {
                ScrollViewer.Cursor = Cursors.SizeAll;
                lastDragPoint = mousePos;
                Mouse.Capture(ScrollViewer);
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            lastMousePositionOnTarget = Mouse.GetPosition(Grid);

            if (e.Delta > 0)
            {
                Slider.Value += 1;
            }
            if (e.Delta < 0)
            {
                Slider.Value -= 1;
            }

            e.Handled = true;
        }

        private void ScrollViewer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ScrollViewer.Cursor = Cursors.Arrow;
            ScrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
            {
                Point? targetBefore = null;
                Point? targetNow = null;

                if (!lastMousePositionOnTarget.HasValue)
                {
                    if (lastCenterPositionOnTarget.HasValue)
                    {
                        var centerOfViewport = new Point(ScrollViewer.ViewportWidth / 2,
                                                         ScrollViewer.ViewportHeight / 2);
                        Point centerOfTargetNow =
                              ScrollViewer.TranslatePoint(centerOfViewport, Grid);

                        targetBefore = lastCenterPositionOnTarget;
                        targetNow = centerOfTargetNow;
                    }
                }
                else
                {
                    targetBefore = lastMousePositionOnTarget;
                    targetNow = Mouse.GetPosition(Grid);

                    lastMousePositionOnTarget = null;
                }

                if (targetBefore.HasValue)
                {
                    double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
                    double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

                    double multiplicatorX = e.ExtentWidth / Grid.Width;
                    double multiplicatorY = e.ExtentHeight / Grid.Height;

                    double newOffsetX = ScrollViewer.HorizontalOffset -
                                        dXInTargetPixels + multiplicatorX;
                    double newOffsetY = ScrollViewer.VerticalOffset -
                                        dYInTargetPixels + multiplicatorY;

                    if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
                    {
                        return;
                    }

                    ScrollViewer.ScrollToHorizontalOffset(newOffsetX);
                    ScrollViewer.ScrollToVerticalOffset(newOffsetY);
                }
            }

        }
    }
}