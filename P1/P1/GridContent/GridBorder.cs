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
    public class GridBorder
    {
        public Border Border { get; private set; }

        /// <summary>
        /// GridBorder Class Constructor
        /// </summary>
        public GridBorder()
        {
            Border = new Border()
            {
                CornerRadius = new CornerRadius(0, 0, 10, 10),
                Width = 760,
                Height = 570,
                BorderBrush = new SolidColorBrush(Color.FromRgb(10, 175, 241)),
                BorderThickness = new Thickness(3)
            };
        }
    }
}