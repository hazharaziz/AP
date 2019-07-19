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
        public Diagram Diagram;
        public Polyline SinusDiagram;
        public string Equation = "";
        public int N;
        public int X0;

        public TaylorSeriesTab(Window window, Grid parentGrid) : base (window, parentGrid) { }

        public override void Draw()
        {
            base.Draw();
            DrawSinusDiagram();
        }

        private void DrawSinusDiagram()
        {
            SinusDiagram = new Polyline() { Stroke = Brushes.Green, StrokeThickness = 2 };
            Point point;
            double j = -20;
            while (j < 20)
            {
                point = new Point();
                point.X = (j * 20) + 520;
                point.Y = -(Math.Sin(j) * 20) + 520;
                SinusDiagram.Points.Add(point);
                j += 0.1;
            }
        }

        private void ExtractEquation()
        {
            double sign = 1;
            if (X0 == 0)
            {
                for (int i = 1; i <= 2 * N - 1; i += 2)
                {
                    Equation += sign == 1 ? $"+{sign / Factorial(i)}x^{i}" : $"{sign / Factorial(i)}x^{i}";
                    sign *= -1;
                }
            }
            else
            {
                for (int i = 0; i <= N; i++)
                {
                    if (i != 0 && i % 2 == 0)
                        sign *= -1;
                    Equation += sign == 1 ? $"+{(sign * Math.Sin(X0)) / Factorial(i)}(x-{X0})^{i}," 
                                          : $"{(sign * Math.Sin(X0)) / Factorial(i)}(x-{X0})^{i},";
                }
            }
        }

        private double Factorial(int i)
            => (i == 0 || i == 1) ? 1 : i * Factorial(i - 1);


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
            try
            {
                N = int.Parse(TextBoxes[0].TextBox.Text);
                X0 = int.Parse(TextBoxes[1].TextBox.Text);
                ExtractEquation();
                Diagram = new Diagram(ScrollViewers[0].Grid,Equation, EquationType.TaylorSeries,
                                        int.Parse(TextBoxes[0].TextBox.Text),int.Parse(TextBoxes[1].TextBox.Text));
                ScrollViewers[0].Grid.Children.Add(SinusDiagram);
                ScrollViewers[0].ScrollViewer.Content = ScrollViewers[0].Grid;
                ParentGrid.Children.Add(ScrollViewers[0].ScrollViewer);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        public override void DrawDiagram()
        {
            ScrollViewers = new GridScrollViewer[] { new GridScrollViewer(740, 405, new Thickness(10, 155, 10, 10), new Thickness(-130,-297.5,-130,-297.5)) };
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