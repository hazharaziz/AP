﻿using System;
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
        public Diagram Diagram { get; private set; }
        
        /// <summary>
        /// DiagramTab Class Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="parentGrid"></param>
        public DiagramTab(Window window, Grid parentGrid) : base(window, parentGrid) { }

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

        /// <summary>
        /// DrawDiagram Method for drawing the diagram of the tab
        /// </summary>
        public override void DrawDiagram()
        {
            ScrollViewers = new GridScrollViewer[] { new GridScrollViewer(740, 380, new Thickness(10, 30, 10, 100),
                                                                                    new Thickness(-180, -310, -180, -310)) };
            ParentGrid.Children.Add(ScrollViewers[0].ScrollViewer);
            ParentGrid.Children.Add(ScrollViewers[0].Slider);
        }


        /// <summary>
        /// DrawButton Method for drawing the buttons of the tab
        /// </summary>
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

        /// <summary>
        /// DrawTextBoxes Method for drawing the textboxes of the tab
        /// </summary>
        public override void DrawTextBoxes()
        {
            TextBoxes = new GridTextBox[]
            {
                new GridTextBox("Function",641, 30, new Thickness(87, 480, 32, 10), "f(x) = ", 60, 30, new Thickness(20, 480, 680, 10),12,HorizontalAlignment.Left,VerticalAlignment.Top)
            };

            foreach (GridTextBox textBox in TextBoxes)
            {
                ParentGrid.Children.Add(textBox.TextBox);
                ParentGrid.Children.Add(textBox.TextBoxLabel.Label);
            }
        }


        public override void DrawTextBlocks() { }

        /// <summary>
        /// DrawButtonClick Method occurs when the draw button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxes[0].TextBox.Text != "")
                {
                    if (Diagram != null && Diagram.Polyline != null)
                        Diagram.Polyline.Points = null;
                    Diagram = new Diagram(ScrollViewers[0].Grid, TextBoxes[0].TextBox.Text, EquationType.Normal);
                    ScrollViewers[0].ScrollViewer.Content = ScrollViewers[0].Grid;
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                TextBoxes.All(t => t.TextBox.Text == "");
            }
        }

        /// <summary>
        /// ClearButtonClick Method occurs when the clear button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            ScrollViewers[0].Grid.Children.Remove(Diagram.Polyline);
            for (int i = 0; i < TextBoxes.Length; i++)
                TextBoxes[i].TextBox.Text = "";
        }
    }
}
