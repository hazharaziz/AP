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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Threading;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer timer = new System.Timers.Timer(1000);
        Tab diagramTab;
        Tab equationsTab;
        Tab taylorSeriesTab;
        CircleClock clock;

        Point? lastCenterPositionOnTarget;
        Point? lastMousePositionOnTarget;
        Point? lastDragPoint;


        public MainWindow()
        {
            
        
            InitializeComponent();

            clock = new CircleClock(this,DateTime.Now,ClockGrid,200,200);
            clock.Draw();

            diagramTab = new DiagramTab(this.Window, MainGrid);
            diagramTab.Draw();

            //scrollViewer.ScrollChanged += Sv1_ScrollChanged;
            //scrollViewer.MouseLeftButtonUp += Sv1_MouseLeftButtonUp;
            //scrollViewer.PreviewMouseLeftButtonUp += Sv1_MouseLeftButtonUp;
            //scrollViewer.PreviewMouseWheel += Sv1_PreviewMouseWheel;
            //scrollViewer.PreviewMouseLeftButtonDown += Sv1_PreviewMouseLeftButtonDown;
            //scrollViewer.MouseMove += Sv1_MouseMove;

            //slider.ValueChanged += Slider_ValueChanged;

        }

        //private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    scaleTransform.ScaleX = e.NewValue;
        //    scaleTransform.ScaleY = e.NewValue;

        //    var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2,
        //                                     scrollViewer.ViewportHeight / 2);
        //    lastCenterPositionOnTarget = scrollViewer.TranslatePoint(centerOfViewport, grid);
        //}

        //private void Sv1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (lastDragPoint.HasValue)
        //    {
        //        Point posNow = e.GetPosition(scrollViewer);

        //        double dX = posNow.X - lastDragPoint.Value.X;
        //        double dY = posNow.Y - lastDragPoint.Value.Y;

        //        lastDragPoint = posNow;

        //        scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - dX);
        //        scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - dY);
        //    }
        //}

        //private void Sv1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var mousePos = e.GetPosition(scrollViewer);
        //    if (mousePos.X <= scrollViewer.ViewportWidth && mousePos.Y <
        //        scrollViewer.ViewportHeight) //make sure we still can use the scrollbars
        //    {
        //        scrollViewer.Cursor = Cursors.SizeAll;
        //        lastDragPoint = mousePos;
        //        Mouse.Capture(scrollViewer);
        //    }
        //}

        //private void Sv1_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        //{
        //    lastMousePositionOnTarget = Mouse.GetPosition(grid);

        //    if (e.Delta > 0)
        //    {
        //        slider.Value += 1;
        //    }
        //    if (e.Delta < 0)
        //    {
        //        slider.Value -= 1;
        //    }

        //    e.Handled = true;
        //}

        //private void Sv1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    scrollViewer.Cursor = Cursors.Arrow;
        //    scrollViewer.ReleaseMouseCapture();
        //    lastDragPoint = null;
        //}

        //private void Sv1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{

        //    if (e.ExtentHeightChange != 0 || e.ExtentWidthChange != 0)
        //    {
        //        Point? targetBefore = null;
        //        Point? targetNow = null;

        //        if (!lastMousePositionOnTarget.HasValue)
        //        {
        //            if (lastCenterPositionOnTarget.HasValue)
        //            {
        //                var centerOfViewport = new Point(scrollViewer.ViewportWidth / 2,
        //                                                 scrollViewer.ViewportHeight / 2);
        //                Point centerOfTargetNow =
        //                      scrollViewer.TranslatePoint(centerOfViewport, grid);

        //                targetBefore = lastCenterPositionOnTarget;
        //                targetNow = centerOfTargetNow;
        //            }
        //        }
        //        else
        //        {
        //            targetBefore = lastMousePositionOnTarget;
        //            targetNow = Mouse.GetPosition(grid);

        //            lastMousePositionOnTarget = null;
        //        }

        //        if (targetBefore.HasValue)
        //        {
        //            double dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
        //            double dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

        //            double multiplicatorX = e.ExtentWidth / grid.Width;
        //            double multiplicatorY = e.ExtentHeight / grid.Height;

        //            double newOffsetX = scrollViewer.HorizontalOffset -
        //                                dXInTargetPixels * multiplicatorX;
        //            double newOffsetY = scrollViewer.VerticalOffset -
        //                                dYInTargetPixels * multiplicatorY;

        //            if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY))
        //            {
        //                return;
        //            }

        //            scrollViewer.ScrollToHorizontalOffset(newOffsetX);
        //            scrollViewer.ScrollToVerticalOffset(newOffsetY);
        //        }
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    this.WindowState = WindowState.Minimized;
                    break;
                case 1:
                    if (this.WindowState != WindowState.Maximized)
                        this.WindowState = WindowState.Maximized;
                    else
                        WindowState = WindowState.Normal;
                    break;
                case 2:
                    Application.Current.Shutdown();
                    break;
            }

        }

        private void MathAnalyzerButton(object sender, RoutedEventArgs e)
        {
            int buttonId = int.Parse(((Button)e.Source).Uid);
            GridCursor.Margin = new Thickness((10 * (buttonId + 1)) + (150 * buttonId), 0, 0, 0);
            equationsTab = new EquationsTab(this.Window, MainGrid);
            taylorSeriesTab = new TaylorSeriesTab(this.Window, MainGrid);


            switch (buttonId)
            {
                case 0:

                    equationsTab.Clear();
                    taylorSeriesTab.Clear();
                    diagramTab.Draw();
                    break;
                case 1:
                    diagramTab.Clear();
                    taylorSeriesTab.Clear();
                    equationsTab.Draw();
                    break;                  
                case 2:
                    diagramTab.Clear();
                    equationsTab.Clear();
                    taylorSeriesTab.Draw();
                    break;
            }

        }


    }
}
