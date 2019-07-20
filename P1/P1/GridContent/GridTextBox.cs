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
    public class GridTextBox
    {
        public TextBoxLabel TextBoxLabel { get; private set; }
        public TextBox TextBox { get; private set; }

        /// <summary>
        /// GridTextBox Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="textBoxThickness"></param>
        /// <param name="labelContent"></param>
        /// <param name="labelWidth"></param>
        /// <param name="labelHeight"></param>
        /// <param name="labelMargin"></param>
        /// <param name="fontSize"></param>
        /// <param name="horizontalAlignment"></param>
        /// <param name="verticalAlignment"></param>
        public GridTextBox(string name, double width, double height, Thickness textBoxThickness, string labelContent = "",
            double labelWidth = 0, double labelHeight = 0, Thickness labelMargin = new Thickness(), double fontSize = 18, 
            HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left, 
            VerticalAlignment verticalAlignment = VerticalAlignment.Top)
        {
            TextBoxLabel = new TextBoxLabel(labelContent, labelWidth, labelHeight, labelMargin);
            TextBox = new TextBox()
            {
                Name = name,
                Width = width,
                Height = height,
                Margin = textBoxThickness,
                FontSize = fontSize,
                HorizontalContentAlignment = horizontalAlignment,
                VerticalContentAlignment = verticalAlignment,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Background = Brushes.White,
                Padding = new Thickness(5, 0, 0, 0),
                AcceptsReturn = true,
            };
        }
    }
}