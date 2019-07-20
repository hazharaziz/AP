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
    public class Diagram
    {
        public Grid ParentGrid { get; private set; }
        public Axis XAxis { get; private set; }
        public Axis YAxis { get; private set; }
        public List<Line> Lines { get; private set; }
        public DiagramEquation Equation { get; private set; }
        public EquationType EquationType { get; private set; }
        public Polyline Polyline { get; private set; }
        public Polyline SinusDiagram { get; private set; }

        /// <summary>
        /// Diagram Class Constructor
        /// </summary>
        /// <param name="parentGrid"></param>
        /// <param name="equation"></param>
        /// <param name="equationType"></param>
        /// <param name="n"></param>
        /// <param name="x0"></param>
        /// <param name="sinusDiagram"></param>
        public Diagram(Grid parentGrid, string equation, EquationType equationType, 
                        int n = 1, int x0 = 0, Polyline sinusDiagram = null)
        {
            ParentGrid = parentGrid;
            EquationType = equationType;
            Equation = new DiagramEquation(equation, equationType,n,x0);
            SinusDiagram = sinusDiagram;
            DrawLines();
            DrawAxises();
            DrawDiagram();
        }

        /// <summary>
        /// DrawDiagram Method for drawing the diagram on the parent grid
        /// </summary>
        private void DrawDiagram()
        {
            if (SinusDiagram != null && !ParentGrid.Children.Contains(SinusDiagram))
                ParentGrid.Children.Add(SinusDiagram);
            Polyline = new Polyline() { Stroke = Brushes.Red, StrokeThickness = 2 };
            Polyline.Points = new PointCollection(Equation.Points);
            ParentGrid.Children.Add(Polyline);
        }

        /// <summary>
        /// DrawLines Method for drawing the diagram scale
        /// </summary>
        private void DrawLines()
        {
            Lines = new List<Line>();
            Line VerticalLine;
            Line HorizontalLine;

            for (int i = 0; i < 250; i++)
            {
                VerticalLine = new Line() { X1 = i * 20, X2 = i * 20, Y1 = 0, Y2 = 1000, Stroke = Brushes.Gray, StrokeThickness = 1 };
                HorizontalLine = new Line() { X1 = 0, X2 = 1000, Y1 = i * 20, Y2 = i * 20, Stroke = Brushes.Gray, StrokeThickness = 1 };
                Lines.Add(VerticalLine);
                Lines.Add(HorizontalLine);
            }

            foreach (Line line in Lines)
                ParentGrid.Children.Add(line);
        }

        /// <summary>
        /// DrawAxises Method for drawing the diagram axises
        /// </summary>
        private void DrawAxises()
        {
            XAxis = new Axis(0, 1000, 520, 520);
            YAxis = new Axis(520, 520, 0, 1000);
            ParentGrid.Children.Add(XAxis.Line);
            ParentGrid.Children.Add(YAxis.Line);
        }
    }
}