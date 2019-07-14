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
    public class Diagram : IDrawing
    {
        public Grid ParentGrid;
        public Button draw;
        public Button clear;
        public Style style;
        public MathAnalyzerButtons Buttons;
        public GridTextBox MaxX;
        public GridTextBox MinX;
        public GridTextBox MaxY;
        public GridTextBox MinY;
        public GridTextBox Function;
        public DiagramGrid DiagramGrid;

        public GridTextBox[] textBoxes;

        public Diagram(Window window, Grid parentGrid)
        {
            ParentGrid = parentGrid;
            style = (Style)Application.Current.Resources["ControlTabButtons"];
            Buttons = new MathAnalyzerButtons(ButtonDetector.DrawDiagramTab);
            DiagramGrid = new DiagramGrid(780, 450, new Thickness(10, 60, 10, 125));

            textBoxes = new GridTextBox[]
            {
                new GridTextBox("MinY",107.5, 40, new Thickness(85, 460, 560, 70),"MIN Y =",60,40,new Thickness(20, 460, 690, 70)),
                new GridTextBox("MaxY",107.5, 40, new Thickness(263, 460, 388, 70), "MAX Y =", 60, 40, new Thickness(198, 460, 502, 70)),
                new GridTextBox("MinX",107.5, 40, new Thickness(441, 460, 210, 70), "MIN X =", 60, 40, new Thickness(376, 460, 324, 70)),
                new GridTextBox("MaxX",107.5, 40, new Thickness(619, 460, 30, 70), "MAX X =", 60, 40, new Thickness(554, 460, 146, 70)),
                new GridTextBox("Function",641, 40, new Thickness(85, 515, 34, 15), "f(x) = ", 60, 40, new Thickness(20, 515, 680, 15))
            };

            Buttons.buttons[0].Click += Diagram_Click;
        }

        private void Diagram_Click(object sender, RoutedEventArgs e)
        {
            var s = textBoxes[0].TextBox.Text;
            MessageBox.Show(s);
        }

        public void Draw()
        {
            ParentGrid.Children.Add(DiagramGrid.Grid);

            foreach (Button button in Buttons.buttons)
                ParentGrid.Children.Add(button);

            foreach (GridTextBox textBox in textBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }
    }
}
