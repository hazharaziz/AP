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

    public class GridButton
    {
        public Button Button;
        public Style style;
        private string Content;

        public GridButton(string content, HorizontalAlignment horizontalAlignment)
        {
            style = (Style)Application.Current.Resources["ControlTabButtons"];
            Content = content;
            Button = ButtonDesign(content, horizontalAlignment);
        }

        private Button ButtonDesign(string content, HorizontalAlignment horizontalAlignment)
        {
            Button button = new Button()
            {
                Content = content,
                Width = 365,
                Height = 40,
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10, 10, 10, 0),
                Style = style,
                Cursor = Cursors.Hand,
            };
            return button;
        }
    }
}
