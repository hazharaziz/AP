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
        public TextBoxLabel TextBoxLabel;
        public TextBox TextBox;
        public Binding binding;

        //public TextBox TextBox
        //{
        //    get { return _TextBox; }
        //    set
        //    {
        //        _TextBox = value;
        //        OnPropertyChanged("TextBox.Text");
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string v)
        //{
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(TextBox.Text));
        //}

        public GridTextBox(string name, double width, double height, Thickness textBoxThickness
            ,string labelContent = "", double labelWidth = 0, double labelHeight = 0, Thickness labelMargin = new Thickness())
        {
            TextBoxLabel = new TextBoxLabel(labelContent, labelWidth, labelHeight, labelMargin);
            TextBox = new TextBox()
            {
                Name = name,
                Width = width,
                Height = height,
                Margin = textBoxThickness,
                FontSize = 18,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                VerticalContentAlignment = VerticalAlignment.Top,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),
                Background = Brushes.White,
                Padding = new Thickness(5, 2, 0, 0),
                AcceptsReturn = true,
            };

            //binding = new Binding("TextBox");
            //binding.Mode = BindingMode.TwoWay;
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
            //BindingOperations.SetBinding(TextBox, TextBox.TextProperty, binding);
        }




    }
}