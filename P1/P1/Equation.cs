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
    public class EquationCalculator
    {

        public string[] Equations;
        public List<string> LeftSideEquations = new List<string>();
        public Dictionary<char, List<double>> VarCoefficients = new Dictionary<char, List<double>>();
        public Matrix<double> CoefficientMatrix;
        public Vector<double> RightSideVector;
        public List<Matrix<double>> CrammerMatrices;
        public string SolutionString;


        

        public EquationCalculator(string equations)
        {
            Equations = equations.Contains(',') ? equations.Split(',') : equations.Split('\n');
            FindVariables();
            Parse();
            SolutionString = GetSolution();
        }

        private string GetSolution()
        {
            string finalResult = string.Empty;

            int size = CoefficientMatrix.RowCount;
            double result;
            double det = CoefficientMatrix.Determinant(CoefficientMatrix, size);

            for (int i = 0; i < size; i++)
            {
                result = CrammerMatrices[i].Determinant(CrammerMatrices[i], size) / det;
                if (i != size - 1)
                    SolutionString += $"{VarCoefficients.ElementAt(i).Key} = {result},";
                SolutionString += $"{VarCoefficients.ElementAt(i).Key} = {result}";
            }

            return SolutionString;

        }

        private void Solve(string equations)
        {


            //if (equations.Contains(',') && det != 0)
            //{
            //    SolutionString = $"{Variables[0]} = {d1.Determinant(2) / det} , {Variables[1]} = {d2.Determinant(2) / det}";
            //}
            //else
            //{
            //    SolutionString = "No unique solution";
            //}
        }

        private void RightSideParse()
        {
            RightSideVector = new Vector<double>(VarCoefficients.Keys.Count);
            foreach (string equation in Equations)
            {
                string[] s = equation.Split('=');
                RightSideVector.Add(double.Parse(s[1]));
            }
        }

        private void Parse()
        {
            StringParse();
            ParseCoefficientMatrix();
            CoefficientMatrix = GetCoefficientMatrix();
            CrammerMatrices = GetCrammerMatrices();
        }

        private List<Matrix<double>> GetCrammerMatrices()
        {
            int size = VarCoefficients.Keys.Count;
            List<Matrix<double>> matrices = new List<Matrix<double>>();
            //Matrix<double> temp = CoefficientMatrix;
            double[,] temp = new double[size,size];
            Matrix<double> matrix;

            for (int i = 0; i <size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    temp[i,j] = CoefficientMatrix[i][j];
                }
            }
                
            int index = 0;
            while(index < size)
            {
                matrix = new Matrix<double>(size,size);

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i][j] = temp[i, j];
                    }
                }

                for (int j = 0; j < size; j++)
                {
                    matrix[j][index] = RightSideVector[j];
                }
                matrices.Add(matrix);
                index++;
            }

            return matrices;


        }

        private void StringParse()
        {
            RightSideParse();
            LeftSideParse();
        }

        private Matrix<double> GetCoefficientMatrix()
        {
            int length = VarCoefficients.Keys.Count;
            Matrix<double> result = new Matrix<double>(length, length);

            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    result[i][j] = VarCoefficients[VarCoefficients.ElementAt(j).Key][i];

            CoefficientParseCompletion();
            return result;
        }

        private void CoefficientParseCompletion()
        {
            int length = VarCoefficients.Keys.Count;

            for (int i = 0; i < length; i++)
            {
                if (VarCoefficients[VarCoefficients.ElementAt(i).Key].Count != length)
                {
                    int j = VarCoefficients[VarCoefficients.ElementAt(i).Key].Count;
                    while (j < length)
                    {
                        VarCoefficients[VarCoefficients.ElementAt(i).Key].Add(0);
                        j++;
                    }
                }
            }
        }

        private void ParseCoefficientMatrix()
        {
            for (int i = 0; i < LeftSideEquations.Count; i++)
            {
                string[] polynomials;
                string newStr = LeftSideEquations[i];
                int counter = 0;
                
                for (int j = 0; j < LeftSideEquations[i].Length; j++)
                {
                    if ((LeftSideEquations[i][j] == '+' || LeftSideEquations[i][j] == '-') && j != 0)
                    {
                        newStr = newStr.Insert(j + counter, ",");
                        counter++;
                    }
                }
                newStr = newStr.Replace(" ", string.Empty);
                polynomials = newStr.Split(',');
                foreach (string p in polynomials)
                    ParsePolynomial(p, i);
            }
        }

        private void ParsePolynomial(string variable, int i)
        {
            string coefficient = string.Empty;

            if (variable.Length > 1)
            {
                coefficient = variable.Substring(0, variable.Length - 1);
                if (!coefficient.Any(char.IsDigit))
                {
                    coefficient += "1";
                }
            }
            else
                coefficient += "1";

            VarCoefficients[variable[variable.Length - 1]][i] = double.Parse(coefficient);    
        }

        private void LeftSideParse()
        {
            string leftSide = string.Empty;
            foreach (string equation in Equations)
            {
                leftSide = equation.Split('=')[0];
                LeftSideEquations.Add(leftSide);
            }
        }

        private void FindVariables()
        {
            foreach (string equation in Equations)
                foreach (char ch in equation)
                    if (char.IsLetter(ch))
                        VarCoefficients[ch] = new List<double>();
            for (int i = 0; i < VarCoefficients.Keys.Count; i++)
                for(int j = 0; j < VarCoefficients.Keys.Count; j++)
                    VarCoefficients[VarCoefficients.ElementAt(i).Key].Add(0);
        }

    }
}