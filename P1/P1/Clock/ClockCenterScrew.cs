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
using System.Timers;

namespace P1
{
    public class ClockCenterScrew
    {
        public Ellipse CenterScrew;

        public ClockCenterScrew(int width, int height, Thickness margin)
        {
            CenterScrew = new Ellipse()
            {
                Width = width,
                Height = height,
                Margin = margin,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Fill = Brushes.Black,
            };
        }


    }
}