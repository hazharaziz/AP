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
    public class ClockHand
    {
        public Border Hand { get; private set; }
        public RotateTransform RotateTransform { get; private set; }

        /// <summary>
        /// ClockHand Class Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="cornerRadius"></param>
        /// <param name="margin"></param>
        /// <param name="color"></param>
        public ClockHand(string name,int width, int height, CornerRadius cornerRadius, Thickness margin, Brush color)
        {
            RotateTransform = new RotateTransform(-90);
            Hand = new Border()
            {
                Name = name,
                Width = width,
                Height = height,
                CornerRadius = cornerRadius,
                Margin = margin,
                Background = color,
                RenderTransformOrigin = new Point(0, 0.5),
                RenderTransform = RotateTransform
            };
        }
    }
}