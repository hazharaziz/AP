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
    public class TaylorSeriesTab : IDrawing, IRemoving
    {
        public Grid ParentGrid;
        public Style style;
        public MathAnalyzerButtons Buttons;
        public GridTextBox N;
        public GridTextBox X0;
        public GridTextBlock FunctionTextBlock;
        public GridBorder TaylorSeriesBorder;

        public GridTextBox[] TextBoxes;

        public TaylorSeriesTab(Window window, Grid parentGrid)
        {
            ParentGrid = parentGrid;
            style = (Style)Application.Current.Resources["ControlTabButtons"];
            Buttons = new MathAnalyzerButtons(ButtonDetector.TaylorSeriesTab);
            TaylorSeriesBorder = new GridBorder();

            TextBoxes = new GridTextBox[]
            {
                new GridTextBox("N",320,40,new Thickness(55, 90, 385, 440),"n =",40,40,new Thickness(10, 90, 710, 440)),
                new GridTextBox("X0", 325, 40, new Thickness(425, 90, 10, 440), "x0 =", 40, 40, new Thickness(380, 90, 340, 440))
            };

            FunctionTextBlock = new GridTextBlock(740, 40, new Thickness(10, 55, 10, 485));
            FunctionTextBlock.TextBlock.Text = "f(x) = Sin(x)";
        }

        public void Draw()
        {
            ParentGrid.Children.Add(TaylorSeriesBorder.Border);
            ParentGrid.Children.Add(FunctionTextBlock.TextBlock);
            foreach (Button button in Buttons.buttons)
                ParentGrid.Children.Add(button);

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }

        public void Remove()
        {
            ParentGrid.Children.Clear();
        }
    }
}