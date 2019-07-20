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
    public class TextBoxLabel
    {
        public Label Label { get; private set; }

        /// <summary>
        /// TextBoxLabel Class Constructor
        /// </summary>
        /// <param name="content"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="labelMargin"></param>
        public TextBoxLabel(string content, double width, double height, Thickness labelMargin)
        {
            Label = new Label()
            {
                Content = content,
                Width = width,
                Height = height,
                Margin = labelMargin,
                FontSize = 12,
                Foreground = Brushes.Black,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontFamily = new FontFamily("Eurostile"),
                FontWeight = FontWeights.DemiBold,
            };
        }
    }
}