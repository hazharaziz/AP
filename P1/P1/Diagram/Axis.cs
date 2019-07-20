
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class Axis
    {
        public Line Line { get; private set; }

        /// <summary>
        /// Axis Class Constructor
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
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