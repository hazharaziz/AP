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
    public enum EquationType { Normal, TaylorSeries};

    public class DiagramTab : Tab
    {
        public Diagram Diagram;
        public Slider Slider;

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
                new GridTextBox("MinY",107.5, 30, new Thickness(85, 485, 560, 50),"MIN Y =",60,30,new Thickness(20, 485, 690, 50),12,HorizontalAlignment.Left,VerticalAlignment.Top),
                new GridTextBox("MaxY",107.5, 30, new Thickness(263, 485, 388, 50), "MAX Y =", 60, 30, new Thickness(198, 485, 502, 50),12,HorizontalAlignment.Left,VerticalAlignment.Top),
                new GridTextBox("MinX",107.5, 30, new Thickness(441, 485, 210, 50), "MIN X =", 60, 30, new Thickness(376, 485, 324, 50),12,HorizontalAlignment.Left,VerticalAlignment.Top),
                new GridTextBox("MaxX",107.5, 30, new Thickness(619, 485, 30, 50), "MAX X =", 60, 30, new Thickness(554, 485, 146, 50),12,HorizontalAlignment.Left,VerticalAlignment.Top),
                new GridTextBox("Function",641, 30, new Thickness(87, 525, 32, 10), "f(x) = ", 60, 30, new Thickness(20, 525, 680, 10),12,HorizontalAlignment.Left,VerticalAlignment.Top)
            };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }

        public override void DrawDiagram()
        {
            ScrollViewers = new GridScrollViewer[] { new GridScrollViewer(740, 380, new Thickness(10, 30, 10, 100),
                                                                                    new Thickness(-180, -310, -180, -310)) };
            ParentGrid.Children.Add(ScrollViewers[0].ScrollViewer);
        }

        public override void DrawTextBlocks() { }

        private void DrawButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxes.All(t => t.TextBox.Text != ""))
                {
                    Diagram = new Diagram(ScrollViewers[0].Grid, TextBoxes[4].TextBox.Text, EquationType.Normal);
                    ScrollViewers[0].ScrollViewer.Content = ScrollViewers[0].Grid;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                TextBoxes.All(t => t.TextBox.Text == "");
            }
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            ScrollViewers[0].Grid.Children.Clear();
            for (int i = 0; i < TextBoxes.Length; i++)
                TextBoxes[i].TextBox.Text = "";
        }
    }
}
