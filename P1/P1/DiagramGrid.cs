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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace P1
{
    public class DiagramGrid
    {
        public Grid Grid;
        
        public DiagramGrid(int width , int height, Thickness gridThickness)
        {
            Grid = new Grid()
            {
                Width = width,
                Height = height,
                Margin = gridThickness,
                Background = Brushes.LightBlue,
            };
        }
    }
}