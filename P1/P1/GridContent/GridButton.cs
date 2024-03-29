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

    public class GridButton
    {
        public Button Button { get; private set; }
        public Style Style { get; private set; }
        private string Content { get; }

        /// <summary>
        /// GridButton Class Constructor
        /// </summary>
        /// <param name="content"></param>
        /// <param name="horizontalAlignment"></param>
        public GridButton(string content, HorizontalAlignment horizontalAlignment)
        {
            Style = (Style)Application.Current.Resources["ControlTabButtons"];
            Content = content;
            Button = ButtonDesign(content, horizontalAlignment);
        }

        /// <summary>
        /// ButtonDesign Method for designing the button
        /// </summary>
        /// <param name="content"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        private Button ButtonDesign(string content, HorizontalAlignment horizontalAlignment)
        {
            Button button = new Button()
            {
                Content = content,
                Width = 365,
                Height = 40,
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(10, 10, 10, 0),
                Style = Style,
                Cursor = Cursors.Hand,
            };
            return button;
        }
    }
}
