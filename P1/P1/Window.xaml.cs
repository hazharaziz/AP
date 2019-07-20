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
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CircleClock Clock;
        Tab DiagramTab;
        Tab EquationsTab;
        Tab TaylorSeriesTab;

        public MainWindow()
        {
            InitializeComponent();

            InitializeClock();
            InitializeTabs();

            Clock.Draw();
            DiagramTab.DrawContent();
        }

        //InitializeClock Method intializing the clock
        private void InitializeClock()
        {
            Clock = new CircleClock(this, DateTime.Now, ClockGrid, 200, 200);
        }

        //InitializeTabs Method initializing the tabs
        private void InitializeTabs()
        {
            DiagramTab = new DiagramTab(this.Window, MainGrid);
            EquationsTab = new EquationsTab(this.Window, MainGrid);
            TaylorSeriesTab = new TaylorSeriesTab(this.Window, MainGrid);
        }

        //TopWindowButtonClick Method occurs when top window buttons are pressed
        private void TopWindowButtonClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);
            switch (index)
            {
                case 0:
                    this.WindowState = WindowState.Minimized;
                    break;
                case 1:
                    Application.Current.Shutdown();
                    break;
            }
        }

        //TabButtonClick Method occurs whenever the tab buttons are clicked
        private void TabButtonClick(object sender, RoutedEventArgs e)
        {
            int buttonId = int.Parse(((Button)e.Source).Uid);
            GridCursor.Margin = new Thickness((10 * (buttonId + 1)) + (150 * buttonId), 0, 0, 0);
            switch (buttonId)
            {
                case 0:
                    TaylorSeriesTab.RemoveContent();
                    EquationsTab.RemoveContent();
                    DiagramTab.DrawContent();
                    break;
                case 1:
                    DiagramTab.RemoveContent();
                    TaylorSeriesTab.RemoveContent();
                    EquationsTab.DrawContent();
                    break;                  
                case 2:
                    DiagramTab.RemoveContent();
                    EquationsTab.RemoveContent();
                    TaylorSeriesTab.DrawContent();
                    break;
            }
        }

        //Window_MouseDown Method for dragging the window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
