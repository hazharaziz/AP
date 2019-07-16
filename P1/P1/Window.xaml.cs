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
        Diagram diagramTab;
        Equations equationsTab;
        TaylorSeries taylorSeriesTab;


        public MainWindow()
        {
            
        
            InitializeComponent();

            //CircleClock circleClock = new CircleClock(180, 180);
            //circleClock.Draw();
            //ClockCanvas.Children.Add(circleClock.Clock);

            DateTime dateTime = DateTime.Now;
            TimeZone timeZone = TimeZone.CurrentTimeZone;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;


            equationsTab = new Equations(this.Window, MainGrid);
            diagramTab = new Diagram(this.Window, MainGrid);
            taylorSeriesTab = new TaylorSeries(this.Window, MainGrid);
            diagramTab.Draw();
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    secondHand.Angle = (DateTime.Now.Second * 6) - 90;
                    minuteHand.Angle = (DateTime.Now.Minute * 6) - 90;
                    hourHand.Angle = (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5) - 90;
                });
            }
            catch (TaskCanceledException)
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            if (index == 2)
                Application.Current.Shutdown();
        }

        private void MathAnalyzerButton(object sender, RoutedEventArgs e)
        {
            int buttonId = int.Parse(((Button)e.Source).Uid);
            GridCursor.Margin = new Thickness((10 * (buttonId + 1)) + (150 * buttonId), 0, 0, 0);

            switch (buttonId)
            {
                case 0:
                    equationsTab.Remove();
                    taylorSeriesTab.Remove();
                    diagramTab.Draw();
                    break;
                case 1:
                    diagramTab.Remove();
                    taylorSeriesTab.Remove();
                    equationsTab.Draw();
                    break;                  
                case 2:
                    diagramTab.Remove();
                    equationsTab.Remove();
                    taylorSeriesTab.Draw();
                    break;

            }

        }
    }
}
