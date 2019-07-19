﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace P1
{
    public class Equation
    {
        private string EquationString;
        private EquationType EquationType;
        public List<Point> Points = new List<Point>();
        private int N;
        private int X0;

        public Equation(string equation, EquationType equationType, int n, int x0)
        {
            EquationString = equation.Replace(" ", string.Empty);
            EquationType = equationType;
            N = n;
            X0 = x0;
            DrawDiagram();
        }

        private void DrawDiagram()
        {
            Point point;
            double j = -20;
            while (j < 20)
            {
                point = new Point();
                point.X = (j * 20) + 520;
                point.Y = -(ParseEquation(j) * 20) + 520;
                Points.Add(point);
                j += 0.1;
            }
        }

        private double ParseEquation(double x)
            => EquationType == EquationType.Normal ? ParseNormalEquation(x,EquationString) : ParseTaylorSeries(x);

        private double ParseTaylorSeries(double x)
        {
            if (X0 == 0)
                return ParseNormalEquation(x,EquationString);
            else
                return SolveTaylorSeries(x);
        }

        private double SolveTaylorSeries(double x)
        {
            double y = 0;
            string[] TaylorPolinomials;
            TaylorPolinomials = EquationString.Split(',').Where(e => e != "").ToArray();

            foreach (string p in TaylorPolinomials)
                y += ParseTaylorPolinomial(x,p);

            return y;
        }

        private double ParseTaylorPolinomial(double x, string p)
        {
            double coefficient = 1;
            double power = 0;

            string[] splittedPolynomial = p.Split(new char[] { '(', ')','^' }).Where(s => s != "").ToArray();
            coefficient = double.Parse(splittedPolynomial[0]);
            double newX = ParseNormalEquation(x, splittedPolynomial[1]);
            power = double.Parse(splittedPolynomial[2]);

            return coefficient * Math.Pow(newX, power);
        }

        private double Factorial(int i)
            => (i == 0 || i == 1) ? 1 : i * Factorial(i - 1);

        private double ParseNormalEquation(double x, string equation)
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

        private double ParsePolynomial(double x, string equation)
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

        private string[] Split(string equation)
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