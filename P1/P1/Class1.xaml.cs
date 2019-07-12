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
    public class Class1 : Window
    {
        public Canvas c;
        public Line l;

        public Class1()
        {
            c = new Canvas();
            l = new Line();
        }

        public void pos(int x1,int x2, int y1, int y2)
        {
            l.X1 = x1;
            l.X2 = x2;
            l.Y1 = y1;
            l.Y2 = y2;
            l.Stroke = Brushes.Black;
        }

        public void canvas(int width,int height)
        {
            c.Width = width;
            c.Height = height;
        }

        public void add()
        {
            c.Children.Add(l);
        }
        
    }
}
