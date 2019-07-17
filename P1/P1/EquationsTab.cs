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
    public class EquationsTab : IDrawing, IRemoving
    {
        public Grid ParentGrid;
        public Style style;
        public MathAnalyzerButtons Buttons;
        public GridTextBox EquationTextBox;
        public GridTextBlock SolutionTextBlock;
        public GridBorder EquationBorder;

        public EquationCalculator Equation;

        public EquationsTab(Window window, Grid parentGrid)
        {
            ParentGrid = parentGrid;
            style = (Style)Application.Current.Resources["ControlTabButtons"];
            Buttons = new MathAnalyzerButtons(ButtonDetector.EquationsTab);
            EquationBorder = new GridBorder();
            EquationTextBox = new GridTextBox("EquationTextBox", 740, 250, new Thickness(10, 30, 10, 230));
            SolutionTextBlock = new GridTextBlock(740,230, new Thickness(10, 320, 10, 10));
            Buttons.buttons[0].Click += CalculateEquation;
            Buttons.buttons[1].Click += Clear;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            EquationTextBox.TextBox.Text = string.Empty;
            SolutionTextBlock.TextBlock.Text = string.Empty;
            Equation = null;
        }

        private void CalculateEquation(object sender, RoutedEventArgs e)
        {
            Equation = new EquationCalculator(EquationTextBox.TextBox.Text);
            SolutionTextBlock.TextBlock.Text = Equation.SolutionString;
        }

        public void Draw()
        {
            ParentGrid.Children.Add(EquationBorder.Border);
            foreach (Button button in Buttons.buttons)
                ParentGrid.Children.Add(button);

            ParentGrid.Children.Add(EquationTextBox.TextBox);
            ParentGrid.Children.Add(SolutionTextBlock.TextBlock);
        }

        public void Remove()
        {
            ParentGrid.Children.Clear();
        }
    }
}