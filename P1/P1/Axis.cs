
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Axis
    {
        public Line Line { get; private set; }
        private int X1;

        public Axis(int x1, int x2, int y1, int y2)
        {
            Line = new Line()
            {
                X1 = x1, X2 = x2, Y1 = y1, Y2 = y2,
                Stroke = Brushes.Black, 
                StrokeThickness = 2
            };
        }
    }
}