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
    public class GridTextBlock
    {
        public TextBlock TextBlock;

        public GridTextBlock(double width, double height, Thickness margin,string text = "")
        {
            TextBlock = new TextBlock()
            {
                Width = width,
                Height = height,
                Margin = margin,
                Background = Brushes.WhiteSmoke,
                Text = text,
                Padding = new Thickness(5, 5, 0, 5),
                FontSize = 14
            };
        }

    }
}