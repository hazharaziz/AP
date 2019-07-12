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

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        
            InitializeComponent();
            Class1 a = new Class1();
            a.canvas(300, 200);
            a.pos(63, 70, 100, 100);
            a.add();
            ClockGrid.Children.Add(a.c);



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            switch (index)
            {
                case 0:
                    //btn1.Background = Brushes.Aquamarine;
                    break;
                case 1:
                    //btn2.Background = Brushes.Aquamarine;
                    break;
                case 2:
                    Window.Close();
                    break;

            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness((10 * (index + 1)) + (150 * index), 0, 0, 0);


            switch (index)
            {
                case 0:
                    GridMain.Background = Brushes.Aquamarine;
                    break;
                case 1:
                    GridMain.Background = Brushes.LightBlue;
                    break;
                case 2:
                    GridMain.Background = Brushes.LawnGreen;
                    break;
            }


        }
    }
}
