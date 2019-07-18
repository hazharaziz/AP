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

        

        public MainWindow()
        {
            
        
            InitializeComponent();

            clock = new CircleClock(this,DateTime.Now,ClockGrid,200,200);
            clock.Draw();

            diagramTab = new DiagramTab(this.Window, MainGrid);
            equationsTab = new EquationsTab(this.Window, MainGrid);
            taylorSeriesTab = new TaylorSeriesTab(this.Window, MainGrid);
            diagramTab.Draw();
        }



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
