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
    public class ClockLine
    {
        public Line Line;

        public ClockLine(double x1, double x2, double y1, double y2, Thickness margin = new Thickness())
        {
            Line = new Line()
            {
                X1 = x1,
                X2 = x2,
                Y1 = y1,
                Y2 = y2,
                Margin = margin,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };
        }
    }
}