using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace P1
{
    public class DiagramEquation
    {
        public string EquationString { get; private set; }
        public EquationType EquationType { get; private set; }
        public List<Point> Points { get; private set; }
        public int N { get; private set; }
        public int X0 { get; private set; }

        /// <summary>
        /// DiagramEquation Class Constructor
        /// </summary>
        /// <param name="equation"></param>
        /// <param name="equationType"></param>
        /// <param name="n"></param>
        /// <param name="x0"></param>
        public DiagramEquation(string equation, EquationType equationType, int n = 1, int x0 = 0)
        {
            EquationString = equation.Replace(" ", string.Empty);
            EquationType = equationType;
            N = n;
            X0 = x0;
            Points = new List<Point>();
            DrawDiagram();
        }

        /// <summary>
        /// DrawDiagram Method for adding the points to the polyline 
        /// </summary>
        private void DrawDiagram()
        {
            Point point;
            double j = -30;
            while (j < 30)
            {
                point = new Point();
                point.X = (j * 20) + 520;
                point.Y = -(CheckEquationType(j) * 20) + 520;
                Points.Add(point);
                j += 0.1;
            }
        }

        /// <summary>
        /// CheckEquationType Method for checking the type of the equation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double CheckEquationType(double x)
            => EquationType == EquationType.Normal ? ParseNormalEquation(x,EquationString) : ParseTaylorSeries(x);

        public double ParseTaylorSeries(double x)
        {
            if (X0 == 0)
                return ParseNormalEquation(x,EquationString);
            else
                return SolveTaylorSeries(x);
        }

        /// <summary>
        /// SolveTaylorSeries Method returning the y coordinate of a point in a taylor series equation
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double SolveTaylorSeries(double x)
        {
            double y = 0;
            string[] TaylorPolinomials;
            TaylorPolinomials = EquationString.Split(',').Where(e => e != "").ToArray();

            foreach (string p in TaylorPolinomials)
                y += ParseTaylorPolinomial(x,p);

            return y;
        }

        /// <summary>
        /// ParseTaylorPolinomial Method for parsing the a taylor polynomial
        /// </summary>
        /// <param name="x"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public double ParseTaylorPolinomial(double x, string p)
        {
            double coefficient = 1;
            double power = 0;

            string[] splittedPolynomial = p.Split(new char[] { '(', ')','^' }).Where(s => s != "").ToArray();
            coefficient = double.Parse(splittedPolynomial[0]);
            double newX = ParseNormalEquation(x, splittedPolynomial[1]);
            power = double.Parse(splittedPolynomial[2]);

            return coefficient * Math.Pow(newX, power);
        }

        /// <summary>
        /// Factorial Method returning the factorial of an integer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double Factorial(int i)
            => (i == 0 || i == 1) ? 1 : i * Factorial(i - 1);

        /// <summary>
        /// ParseNormalEquation Method parsing a normal equation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="equation"></param>
        /// <returns></returns>
        public double ParseNormalEquation(double x, string equation)
        {
            double y = 0;
            equation = equation.Replace(" ", string.Empty);
            string[] polynomials = Split(equation);

            for (int i = 0; i < polynomials.Length; i++)
            {
                if (polynomials[i].Any(char.IsLetter))
                {
                    if (!polynomials[i].Contains('^'))
                        polynomials[i] += "^1";
                }
                else
                    polynomials[i] += "x^0";

                y += ParsePolynomial(x, polynomials[i]);
            }
            return y;
        }

        /// <summary>
        /// ParsePolynomial Method for parsing a polynomial
        /// </summary>
        /// <param name="x"></param>
        /// <param name="equation"></param>
        /// <returns></returns>
        public double ParsePolynomial(double x, string equation)
        {
            string coefficient = "";
            string power = "0";

            if (equation.Length > 1)
            {
                power += equation.Split('^')[1];
                for (int i = 0; i < equation.Length; i++)
                {
                    if (char.IsLetter(equation[i]))
                        break;
                    coefficient += equation[i];
                }
                coefficient += coefficient == "" ? "1" : "";
            }
            else
            {
                if (!char.IsLetter(equation[0]))
                    coefficient += equation;
                coefficient += "1";
            }

            coefficient += !coefficient.Any(char.IsDigit) ? "1" : "";

            return (double.Parse(coefficient) * Math.Pow(x, double.Parse(power)));
        }

        /// <summary>
        /// Split Method for splitting the polynomials of an equation
        /// </summary>
        /// <param name="equation"></param>
        /// <returns></returns>
        public string[] Split(string equation)
        {
            equation = equation.Replace(" ", string.Empty);
            string[] polynomials;
            string newStr = equation;
            int counter = 0;

            for (int j = 0; j < equation.Length; j++)
            {
                if ((equation[j] == '+' || equation[j] == '-') && j != 0)
                {
                    newStr = newStr.Insert(j + counter, ",");
                    counter++;
                }
            }
            newStr = newStr.Replace(" ", string.Empty);
            polynomials = newStr.Split(',').Where(p => p != "").ToArray();

            return polynomials;
        }
    }
}