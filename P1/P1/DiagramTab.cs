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
    public class DiagramTab : Tab
    {
        public DiagramTab(Window window, Grid parentGrid) : base(window, parentGrid)
        {

        }

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
                new GridTextBox("MinY",107.5, 40, new Thickness(85, 460, 560, 70),"MIN Y =",60,40,new Thickness(20, 460, 690, 70)),
                new GridTextBox("MaxY",107.5, 40, new Thickness(263, 460, 388, 70), "MAX Y =", 60, 40, new Thickness(198, 460, 502, 70)),
                new GridTextBox("MinX",107.5, 40, new Thickness(441, 460, 210, 70), "MIN X =", 60, 40, new Thickness(376, 460, 324, 70)),
                new GridTextBox("MaxX",107.5, 40, new Thickness(619, 460, 30, 70), "MAX X =", 60, 40, new Thickness(554, 460, 146, 70)),
                new GridTextBox("Function",641, 40, new Thickness(85, 515, 34, 15), "f(x) = ", 60, 40, new Thickness(20, 515, 680, 15))
            };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }

        public override void DrawDiagramGrids()
        {
            DiagramGrids = new DiagramGrid[] { new DiagramGrid(740, 380, new Thickness(10, 30, 10, 100))};
            foreach (DiagramGrid grid in DiagramGrids)
                ParentGrid.Children.Add(grid.Grid);
        }

        public override void DrawTextBlocks() { }

        private void DrawButtonClick(object sender, RoutedEventArgs e)
        {
            var s = TextBoxes[0].TextBox.Text;
            MessageBox.Show(s);
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
