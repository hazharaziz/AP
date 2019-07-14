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
    public enum ButtonDetector { DrawDiagramTab = 0x01,EquationsTab = 0x02,TaylorSeriesTab = 0x04};

    public class MathAnalyzerButtons
    {
        ButtonDetector ButtonDetector;
        public Button[] buttons = new Button[2];
        public Style style;

        public MathAnalyzerButtons(ButtonDetector buttonDetector)
        {
            style = (Style)Application.Current.Resources["ControlTabButtons"];
            ButtonDetector = buttonDetector;
            buttons[0] = ButtonDesigner(HorizontalAlignment.Left);
            buttons[1] = ButtonDesigner(HorizontalAlignment.Right);
            if (ButtonDetector == ButtonDetector.EquationsTab)
                buttons[0].Content = "CALCULATE";
            else
                buttons[0].Content = "DRAW";
            buttons[1].Content = "CLEAR";
        }

        private Button ButtonDesigner(HorizontalAlignment horizontalAlignment)
        {
            Button button = new Button()
            {
                Width = 365,
                Height = 40,
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10, 10, 10, 0),
                Style = style
            };
            return button;
        }
    }
}
