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
    public enum SolutionState { Unique, NoSolution, Infinite};


    public class LinearEquations
    {

        public string[] Equations;
        public List<string> LeftSideEquations = new List<string>();
        public Dictionary<char, List<double>> VarCoefficients = new Dictionary<char, List<double>>();
        public Matrix<double> CoefficientMatrix;
        public Vector<double> RightSideVector;
        public List<Matrix<double>> CrammerMatrices;
        public Matrix<double> AugmentedMatrix;
        public SolutionState SolutionState;
        private double Determinant;
        public string SolutionString;
        



        public LinearEquations(string equations)
        {
            Equations = equations.Contains(',') ? equations.Split(',') : equations.Split(new char[] { '\r', '\n' });
            FindVariables();
            Parse();
            SolveEquation();
        }

        private void FindVariables()
        {
            Equations = Equations.Where(eq => eq != "" || eq != string.Empty).ToArray();

            foreach (string equation in Equations)
                foreach (char ch in equation)
                    if (char.IsLetter(ch))
                        VarCoefficients[ch] = new List<double>();
            for (int i = 0; i < VarCoefficients.Keys.Count; i++)
                for (int j = 0; j < VarCoefficients.Keys.Count; j++)
                    VarCoefficients[VarCoefficients.ElementAt(i).Key].Add(0);
        }

        private void Parse()
        {
            StringParse();
            ParseCoefficientMatrix();
            CoefficientMatrix = GetCoefficientMatrix();
            CrammerMatrices = GetCrammerMatrices();
            AugmentedMatrix = GetAugmentedMatrix();
            Determinant = Matrix<double>.Determinant(CoefficientMatrix, CoefficientMatrix.RowCount);
        }

        private void SolveEquation()
        {
            if (Determinant != 0)
                SolutionState = SolutionState.Unique;
            else
                SolutionState = AugmentedMatrixCheck();
            SolutionString = GetSolution();
        }

        private SolutionState AugmentedMatrixCheck()
        {
            SolutionState state = SolutionState.Infinite;
            Matrix<double> temp = AugmentedMatrix.Copy(AugmentedMatrix.RowCount, AugmentedMatrix.ColumnCount);
            for (int i = 0; i < AugmentedMatrix.RowCount; i++)
            {
                for (int j = i + 1; j < AugmentedMatrix.RowCount; j++)
                {
                    for (int k = i; k < AugmentedMatrix.ColumnCount; k++)
                        AugmentedMatrix[j][k] += ((-temp[j][i] / temp[i][i]) * temp[i][k]);
                }
                temp = AugmentedMatrix.Copy(temp.RowCount, temp.ColumnCount);
            }

            for (int i = 0; i < temp.ColumnCount; i++)
            {
                if (temp[temp.RowCount - 1][temp.ColumnCount - 1] != 0)
                    state = SolutionState.NoSolution;
            }

            return state;
        }

        private string GetSolution()
        {
            string finalResult = "";
            int size = CoefficientMatrix.RowCount;

            if (SolutionState == SolutionState.Unique)
                for (int i = 0; i < size; i++)
                {
                    double numerator = Matrix<double>.Determinant(CrammerMatrices[i], size);
                    finalResult += i != size - 1 ? $"{VarCoefficients.ElementAt(i).Key} = {numerator / Determinant} , "
                                                   : $"{VarCoefficients.ElementAt(i).Key} = {numerator / Determinant}";
                }
            else if (SolutionState == SolutionState.Infinite)
                finalResult = "No Unique Solution";
            else
                finalResult = "No Solution";

            return finalResult;
        }


        private void StringParse()
        {
            RightSideParse();
            LeftSideParse();
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

        private void LeftSideParse()
        {
            string leftSide = string.Empty;
            foreach (string equation in Equations)
            {
                leftSide = equation.Split('=')[0];
                LeftSideEquations.Add(leftSide);
            }
        }


        private void ParseCoefficientMatrix()
        {
            for (int i = 0; i < LeftSideEquations.Count; i++)
            {
                string[] polynomials = Split(LeftSideEquations[i]);
                foreach (string p in polynomials)
                    ParsePolynomial(p, i);
            }
        }

        private string[] Split(string polynomial)
        {
            string[] polynomials;
            string newStr = polynomial;
            int counter = 0;

            for (int j = 0; j < polynomial.Length; j++)
            {
                if ((polynomial[j] == '+' || polynomial[j] == '-') && j != 0)
                {
                    newStr = newStr.Insert(j + counter, ",");
                    counter++;
                }
            }
            newStr = newStr.Replace(" ", string.Empty);
            polynomials = newStr.Split(',');

            return polynomials;
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

        private List<Matrix<double>> GetCrammerMatrices()
        {
            int size = CoefficientMatrix.RowCount;
            List<Matrix<double>> matrices = new List<Matrix<double>>();
            Matrix<double> matrix;

            int index = 0;
            while (index < size)
            {
                matrix = CoefficientMatrix.Copy(size, size);
                for (int j = 0; j < size; j++)
                    matrix[j][index] = RightSideVector[j];
                matrices.Add(matrix);
                index++;
            }
            return matrices;
        }

        private Matrix<double> GetAugmentedMatrix()
        {
            int size = CoefficientMatrix.RowCount;
            Matrix<double> augmentedMatrix = new Matrix<double>(size , size + 1);

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    augmentedMatrix[i][j] = CoefficientMatrix[i][j];
            for (int i = 0; i < size; i++)
                augmentedMatrix[i][size] = RightSideVector[i];

            return augmentedMatrix;
        }
    }
}