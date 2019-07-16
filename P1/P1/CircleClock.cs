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
    public class CircleClock : IDrawing
    {
        public Ellipse Clock;

        public CircleClock(Window window, Grid parentGrid, int width, int height)
        {
            Clock = new Ellipse();
        }

        public void Draw()
        {
            Clock.Stroke = Brushes.Black;
            Clock.StrokeThickness = 2;
            Clock.Margin = new Thickness(0, 20, 20, 20);
        }
    }
}
