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
    public class CircleClock : Window, IDrawing
    {
        public Canvas ClockCanvas;
        private Ellipse Clock;

        public CircleClock(int width, int height)
        {
            ClockCanvas = DrawCanvas(width, height);
            Clock = new Ellipse();

        }
        public void Draw()
        {

            Clock.Width = 180;
            Clock.Height = 180;
            Clock.Stroke = Brushes.Black;
            Clock.StrokeThickness = 2;
            ClockCanvas.Children.Add(Clock);
            
        }

        public Canvas DrawCanvas(int width, int height)
        {
            Canvas canvas = new Canvas();
            canvas.Width = width;
            canvas.Height = height;
            return canvas;
        }
    }
}
