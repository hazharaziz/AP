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
        public TextBlock TextBlock { get; private set; }

        /// <summary>
        /// GridTextBlock Class Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="margin"></param>
        public GridTextBlock(double width, double height, Thickness margin)
        {
            TextBlock = new TextBlock()
            {
                Width = width,
                Height = height,
                Margin = margin,
                Background = Brushes.WhiteSmoke,
                Foreground = Brushes.Black,
                Padding = new Thickness(5, 5, 0, 5),
                FontSize = 18
            };
        }

    }
}