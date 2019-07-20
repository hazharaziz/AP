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
using System.Timers;

namespace P1
{
    public class CircleClock 
    {
        private Window Window;
        private Grid ParentGrid;
        private Ellipse Clock;
        private ClockLine[] ClockLines;
        private ClockHand[] ClockHands;
        private Timer Timer;
        private ClockCenterScrew ClockCenterScrew;

        /// <summary>
        /// CircleClock Class Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="dateTime"></param>
        /// <param name="parentGrid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CircleClock(Window window, DateTime dateTime ,Grid parentGrid, int width, int height)
        {
            Window = window;
            ParentGrid = parentGrid;
            Clock = new Ellipse() { Width = width, Height = height };
            Timer = new Timer(1000);
            Timer.Elapsed += TimerElapsed;
            Timer.Enabled = true;
            ClockCenterScrew = new ClockCenterScrew(5, 5, new Thickness(97.5, 97.5, 97.5, 97.5));
            DrawClockLines();
            DrawClockHands();
        }

        /// <summary>
        /// TimerElapsed Method for rotating the clock hands 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Window.Dispatcher.Invoke(() =>
                {
                    ClockHands[0].RotateTransform.Angle = (DateTime.Now.Second * 6) - 90;
                    ClockHands[1].RotateTransform.Angle = (DateTime.Now.Minute * 6) - 90;
                    ClockHands[2].RotateTransform.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5) - 90;
                });
            }
            catch (TaskCanceledException)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// DrawClockHands Method for drawing the clock hands
        /// </summary>
        private void DrawClockHands()
        {
            ClockHands = new ClockHand[]
            {
                new ClockHand("secondHand", 90, 1, new CornerRadius(0,2,2,0), new Thickness(100,99,10,99),Brushes.Red),
                new ClockHand("minuteHand", 70, 2, new CornerRadius(0,2,2,0), new Thickness(100,97,30,97),Brushes.Black),
                new ClockHand("hourHand", 50, 4, new CornerRadius(0,2,2,0), new Thickness(100,98,50,98),Brushes.Black),
            };
        }

        /// <summary>
        /// Draw Method for drawing the clock on the parent grid
        /// </summary>
        public void Draw()
        {
            Clock.Stroke = Brushes.Black;
            Clock.StrokeThickness = 2;
            ParentGrid.Children.Add(Clock);
            foreach (ClockLine clockLine in ClockLines)
                ParentGrid.Children.Add(clockLine.Line);
            foreach (ClockHand clockHand in ClockHands)
                ParentGrid.Children.Add(clockHand.Hand);
            ParentGrid.Children.Add(ClockCenterScrew.CenterScrew);
        }

        /// <summary>
        /// DrawClockLines Method for drawing the clock ticks
        /// </summary>
        private void DrawClockLines()
        {
            ClockLines = new ClockLine[]
            {
                new ClockLine(3,7,100,100),
                new ClockLine(197,193,100,100),
                new ClockLine(100,100,3,7),
                new ClockLine(100,100,197,193),
                new ClockLine(146,144,16.88,20.32, new Thickness(2.5,-1,0,0)),
                new ClockLine(144,146,16.88,20.32, new Thickness(-92,-1,0,0)),
                new ClockLine(20.88,24.32,44,46, new Thickness(-5,7.5,5,-8)),
                new ClockLine(179.12,175.68,144,142, new Thickness(5,4,-5,-4)),
                new ClockLine(144,146,171.68,175.12, new Thickness(2.5,9,-3,-9)),
                new ClockLine(52,50,171.68,175.12, new Thickness(2,8,0,0)),
                new ClockLine(16.88,20.32,146,144, new Thickness(-0.5,2,0,-2)),
                new ClockLine(179.12,175.68,44,46, new Thickness(4.5,7.5,0,0)),
            };
        }
    }
}
