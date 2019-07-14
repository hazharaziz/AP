﻿using System;
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

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Diagram diagram;

        public MainWindow()
        {

        
            InitializeComponent();

            CircleClock circleClock = new CircleClock(180, 180);
            circleClock.Draw();
            
            ClockCanvas.Children.Add(circleClock.Clock);
            

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

            switch(buttonId)
            {
                case 0:
                    diagram = new Diagram(this.Window,DrawDiagramGrid);
                    diagram.Draw();
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }

        }
    }
}
