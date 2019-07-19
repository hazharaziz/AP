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
    public class TaylorSeriesTab : Tab
    {
        public TaylorSeriesTab(Window window, Grid parentGrid) : base (window, parentGrid) { }

        public override void DrawButtons()
        {
            Buttons = new GridButton[]
            {
                new GridButton("DRAW",HorizontalAlignment.Left),
                new GridButton("CLEAR",HorizontalAlignment.Right)
            };


            foreach (GridButton button in Buttons)
                ParentGrid.Children.Add(button.Button);

            Buttons[0].Button.Click += DrawButtonClick;
            Buttons[1].Button.Click += ClearButtonClick;

        }

        public override void DrawTextBoxes()
        {
            TextBoxes = new GridTextBox[]
            {
                new GridTextBox("N",320,40,new Thickness(55, 105, 385, 420),"n =",40,40,new Thickness(10, 105, 710, 420)),
                new GridTextBox("X0", 325, 40, new Thickness(425, 105, 10, 420), "x0 =", 40, 40, new Thickness(380, 105, 340, 420))
            };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }


        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DrawButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }


        public override void DrawDiagramGrids()
        {
            ScrollViewers = new GridScrollViewer[] { new GridScrollViewer(740, 405, new Thickness(10, 155, 10, 10), new Thickness()) };
            ParentGrid.Children.Add(ScrollViewers[0].Grid);
        }

        public override void DrawTextBlocks()
        {
            TextBlocks = new GridTextBlock[] { new GridTextBlock(740, 40, new Thickness(10, 55, 10, 470)) };
            TextBlocks[0].TextBlock.Text = "f(x) = Sin(x)";
            foreach (GridTextBlock textBlock in TextBlocks)
                ParentGrid.Children.Add(textBlock.TextBlock);
        }
    }
}