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
        public LinearEquations Equation { get; private set; }

        /// <summary>
        /// EquationsTab Class Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="parentGrid"></param>
        public EquationsTab(Window window, Grid parentGrid) : base (window, parentGrid) { }

        /// <summary>
        /// DrawContent Method for drawing the content of the tab
        /// </summary>
        public override void DrawContent()
        {
            DrawBorder();
            DrawDiagram();
            DrawButtons();
            DrawTextBoxes();
            DrawTextBlocks();
        }

        /// <summary>
        /// RemoveContent Method for removing the content of the tab
        /// </summary>
        public override void RemoveContent()
        {
            ParentGrid.Children.Clear();
        }

        public override void DrawDiagram() { }

        /// <summary>
        /// DrawButton Method for drawing the buttons of the tab
        /// </summary>
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

        /// <summary>
        /// DrawTextBoxes Method for drawing the textboxes of the tab
        /// </summary>
        public override void DrawTextBoxes()
        {
            TextBoxes = new GridTextBox[] { new GridTextBox("EquationTextBox", 740, 250, new Thickness(10, 30, 10, 230)) };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }

        /// <summary>
        /// DrawTextBlocks Method for drawing the textblocks of the tab
        /// </summary>
        public override void DrawTextBlocks()
        {
            TextBlocks = new GridTextBlock[] { new GridTextBlock(740, 230, new Thickness(10, 320, 10, 10)) };
            foreach (GridTextBlock textBlock in TextBlocks)
            {
                ParentGrid.Children.Add(textBlock.TextBlock);
            }
        }

        /// <summary>
        /// CalculateButtonClick Method occurs when the calculate button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxes[0].TextBox.Text != "")
                {
                    Equation = new LinearEquations(TextBoxes[0].TextBox.Text);
                    TextBlocks[0].TextBlock.Text = Equation.SolutionString;
                }
            }
            catch (Exception exception) { MessageBox.Show(exception.Message); }
        }

        /// <summary>
        /// ClearButtonClick Method occurs when the clear button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxes[0].TextBox.Text = string.Empty;
            TextBlocks[0].TextBlock.Text = string.Empty;
            Equation = null;
        }
    }
}