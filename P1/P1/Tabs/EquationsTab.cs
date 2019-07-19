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
    public class EquationsTab : Tab
    {
        public LinearEquations Equation;

        public EquationsTab(Window window, Grid parentGrid) : base (window, parentGrid)
        {
        }

        public override void DrawButtons()
        {
            Buttons = new GridButton[]
            {
                new GridButton("CALCULATE",HorizontalAlignment.Left),
                new GridButton("CLEAR",HorizontalAlignment.Right)
            };


            foreach (GridButton button in Buttons)
                ParentGrid.Children.Add(button.Button);

            Buttons[0].Button.Click += CalculateButtonClick;
            Buttons[1].Button.Click += ClearButtonClick;

        }

        public override void DrawTextBoxes()
        {
            TextBoxes = new GridTextBox[] { new GridTextBox("EquationTextBox", 740, 250, new Thickness(10, 30, 10, 230)) };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }


        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxes[0].TextBox.Text = string.Empty;
            TextBlocks[0].TextBlock.Text = string.Empty;
            Equation = null;
        }

        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (TextBoxes[0].TextBox.Text != "")
            {
                Equation = new LinearEquations(TextBoxes[0].TextBox.Text);
                TextBlocks[0].TextBlock.Text = Equation.SolutionString;
            }
        }

        public override void DrawDiagram() { }

        public override void DrawTextBlocks()
        {
            TextBlocks = new GridTextBlock[] { new GridTextBlock(740, 230, new Thickness(10, 320, 10, 10)) };
            foreach (GridTextBlock textBlock in TextBlocks)
            {
                ParentGrid.Children.Add(textBlock.TextBlock);
            }
        }
    }
}