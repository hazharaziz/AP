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
    public abstract class Tab
    {
        public Window Window;
        public Grid ParentGrid;
        public Style Style;
        public GridBorder Border;
        public GridScrollViewer[] ScrollViewers;
        public GridButton[] Buttons;
        public GridTextBox[] TextBoxes;
        public GridTextBlock[] TextBlocks;
        
        /// <summary>
        /// Tab Class Constructor
        /// </summary>
        /// <param name="window"></param>
        /// <param name="parentGrid"></param>
        public Tab(Window window, Grid parentGrid)
        {
            Window = window;
            ParentGrid = parentGrid;
            Style = (Style)Application.Current.Resources["ControlTabButtons"];
        }

        /// <summary>
        /// DrawBorder for drawing the border of the tab
        /// </summary>
        public virtual void DrawBorder()
        {
            Border = new GridBorder();
            ParentGrid.Children.Add(Border.Border);
        }

        public abstract void DrawContent();
        public abstract void DrawDiagram();
        public abstract void DrawButtons();
        public abstract void DrawTextBoxes();
        public abstract void DrawTextBlocks();
        public abstract void RemoveContent();
    }
}
