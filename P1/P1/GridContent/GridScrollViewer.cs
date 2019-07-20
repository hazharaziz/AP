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
        public ScaleTransform ScaleTransform { get; private set; }
        private Point? lastCenterPositionOnTarget;
        private Point? lastMousePositionOnTarget;
        private Point? lastDragPoint;

        /// <summary>
        /// GridScrollViewer Class Constructor
        /// </summary>
        /// <param name="viewerWidth"></param>
        /// <param name="viewerHeight"></param>
        /// <param name="viewerMargin"></param>
        /// <param name="gridMargin"></param>
        public GridScrollViewer(int viewerWidth , int viewerHeight, Thickness viewerMargin, Thickness gridMargin)
        {
            DrawScrollViewer(viewerMargin);
            DrawSlider();
            DrawGrid(gridMargin);
        }

        /// <summary>
        /// DrawGrid Method for drawing the grid
        /// </summary>
        /// <param name="gridMargin"></param>
        private void DrawGrid(Thickness gridMargin)
        {
            Grid = new Grid()
            {
                Width = 1000,
                Height = 1000,
                Margin = gridMargin,
                Background = Brushes.LightBlue,
            };
            ScaleTransform = new ScaleTransform(1, 1, ScrollViewer.Width / 2, ScrollViewer.Height / 2);
            Grid.LayoutTransform = ScaleTransform;
            ScrollViewer.Content = Grid;
        }

        /// <summary>
        /// DrawSlider Method for drawing the slider
        /// </summary>
        private void DrawSlider()
        {
            Slider = new Slider()
            {
                Width = 740,
                Height = 18,
                Minimum = 1,
                Maximum = 20,
                Background = Brushes.Yellow,
                Foreground = Brushes.Blue,
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(10, 455, 10, 97),
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };

            Slider.ValueChanged += Slider_ValueChanged;
        }

        /// <summary>
        /// DrawScrollViewer Method for drawing the scrollviewer 
        /// </summary>
        /// <param name="viewerMargin"></param>
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

            ScrollViewerEventHandler();
        }

        /// <summary>
        /// ScrollViewerEventHandler Method for handling drag-and-drop and zooming in and out of the scrollviewer
        /// </summary>
        private void ScrollViewerEventHandler()
        {
            ScrollViewer.ScrollChanged += ScrollViewer_ScrollChanged; ;
            ScrollViewer.MouseLeftButtonUp += ScrollViewer_MouseLeftButtonUp;
            ScrollViewer.PreviewMouseLeftButtonUp += ScrollViewer_MouseLeftButtonUp;
            ScrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
            ScrollViewer.PreviewMouseLeftButtonDown += ScrollViewer_PreviewMouseLeftButtonDown;
            ScrollViewer.MouseMove += ScrollViewer_MouseMove;
        }

        //Slider_ValueChanged Method for handling the change of slider range
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ScaleTransform.ScaleX = e.NewValue;
            ScaleTransform.ScaleY = e.NewValue;

            var centerOfViewport = new Point(ScrollViewer.ViewportWidth / 2,
                                             ScrollViewer.ViewportHeight / 2);
            lastCenterPositionOnTarget = ScrollViewer.TranslatePoint(centerOfViewport, Grid);
        }

        //ScrollViewer_MouseMove occurs when the mouse moves over the scrollviewer
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

        //ScrollViewer_PreviewMouseLeftButtonDown Method occurs when the mouse left button pressed over the scrollviewer
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

        //ScrollViewer_PreviewMouseWheel Method occurs when the user rotates the mouse wheel over the scrollviewer
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

        //ScrollViewer_MouseLeftButtonUp Method occurs when the mouse left button is released while is on the scrollviewer
        private void ScrollViewer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ScrollViewer.Cursor = Cursors.Arrow;
            ScrollViewer.ReleaseMouseCapture();
            lastDragPoint = null;
        }

        //ScrollViewer_ScrollChanged Method occurs when the scroll changes
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
                                        dXInTargetPixels / multiplicatorX;
                    double newOffsetY = ScrollViewer.VerticalOffset -
                                        dYInTargetPixels / multiplicatorY;

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