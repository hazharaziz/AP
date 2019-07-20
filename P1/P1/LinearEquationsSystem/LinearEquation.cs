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
        public string[] Equations { get; private set; }
        public List<string> LeftSideEquations { get; private set; }
        public Dictionary<char, List<double>> VarCoefficients { get; private set; }
        public Matrix<double> CoefficientMatrix { get; private set; }
        public Vector<double> RightSideVector { get; private set; }
        public List<Matrix<double>> CrammerMatrices { get; private set; }
        public Matrix<double> AugmentedMatrix { get; private set; }
        public SolutionState SolutionState { get; private set; }
        public double Determinant { get; private set; }
        public string SolutionString { get; private set; }

        /// <summary>
        /// LinearEquations Class Constructor
        /// </summary>
        /// <param name="equations"></param>
        public LinearEquations(string equations)
        {
            Equations = equations.Contains(',') ? equations.Split(',') : equations.Split(new char[] { '\r', '\n' });
            FindVariables();
            Parse();
            SolveEquation();
        }

        /// <summary>
        /// FindVariables Method for extracting the variables out of the equation 
        /// </summary>
        private void FindVariables()
        {
            Equations = Equations.Where(eq => eq != "" || eq != string.Empty).ToArray();
            VarCoefficients = new Dictionary<char, List<double>>();

            foreach (string equation in Equations)
                foreach (char ch in equation)
                    if (char.IsLetter(ch))
                        VarCoefficients[ch] = new List<double>();
            for (int i = 0; i < VarCoefficients.Keys.Count; i++)
                for (int j = 0; j < VarCoefficients.Keys.Count; j++)
                    VarCoefficients[VarCoefficients.ElementAt(i).Key].Add(0);
        }

        /// <summary>
        /// Parse Method for parsing the equation
        /// </summary>
        private void Parse()
        {
            StringParse();
            ParseCoefficientMatrix();
            CoefficientMatrix = GetCoefficientMatrix();
            CrammerMatrices = GetCramerMatrices();
            AugmentedMatrix = GetAugmentedMatrix();
            Determinant = Matrix<double>.Determinant(CoefficientMatrix, CoefficientMatrix.RowCount);
        }

        /// <summary>
        /// SolveEquation Method solving the equation according to the solution state of the equation
        /// </summary>
        private void SolveEquation()
        {
            if (Determinant != 0)
                SolutionState = SolutionState.Unique;
            else
                SolutionState = AugmentedMatrixCheck();
            SolutionString = GetSolution();
        }

        /// <summary>
        /// AugmentedMatrixCheck Method returning an the solution state of the equation
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// GetSolution Method returning the equation solution
        /// </summary>
        /// <returns></returns>
        private string GetSolution()
        {
            string finalResult = "";
            int size = CoefficientMatrix.RowCount;

            if (SolutionState == SolutionState.Unique)
                for (int i = 0; i < size; i++)
                {
                    double numerator = Matrix<double>.Determinant(CrammerMatrices[i], size);
                    finalResult += i != size - 1 ? string.Format("{0} = {1:0.0} , ",VarCoefficients.ElementAt(i).Key,numerator / Determinant)
                                                 : string.Format("{0} = {1:0.0}", VarCoefficients.ElementAt(i).Key, numerator / Determinant);
                }
            else if (SolutionState == SolutionState.Infinite)
                finalResult = "No Unique Solution";
            else
                finalResult = "No Solution";

            return finalResult;
        }

        /// <summary>
        /// StringParse Method for parsing both sides of the equation 
        /// </summary>
        private void StringParse()
        {
            RightSideVector = new Vector<double>(VarCoefficients.Keys.Count);
            LeftSideEquations = new List<string>();
            LeftSideParse();
            RightSideParse();
        }

        /// <summary>
        /// RightSideParse Method extracting the right side numbers of the equation
        /// </summary>
        private void RightSideParse()
        {
            List<string> rightSide;
            int i = 0;
            foreach (string equation in Equations)
            {
                rightSide = Split(equation.Split('=')[1].Replace(" ", string.Empty)).ToList();
                RightSideVector[i] += rightSide.Where(p => !p.Any(char.IsLetter)).Select(n => double.Parse(n)).ToList().Sum();

                rightSide = rightSide.Where(p => p.Any(char.IsLetter)).ToList();
                for (int j = 0; j < rightSide.Count; j++)
                {
                    if (rightSide[j].Contains("+"))
                        rightSide[j] = rightSide[j].Replace("+", "-");
                    else if (rightSide[j].Contains("-"))
                        rightSide[j] = rightSide[j].Replace("-", "+");

                    else
                        rightSide[j] = rightSide[j].Insert(0, "-");
                }
                LeftSideEquations[i] += string.Join("", rightSide);
                i++;
            }
        }

        /// <summary>
        /// LeftSideParse Method parsing the left side equations
        /// </summary>
        private void LeftSideParse()
        {
            List<string> leftSide;
            int i = 0;
            foreach (string equation in Equations)
            {
                leftSide = Split(equation.Split('=')[0].Replace(" ",string.Empty)).ToList();
                
                RightSideVector[i] -= leftSide.Where(p => !p.Any(char.IsLetter)).Select(n => double.Parse(n)).ToList().Sum();
                leftSide = leftSide.Where(p => p.Any(char.IsLetter)).ToList();

                for (int j = 0; j < leftSide.Count; j++)
                {
                    if (!leftSide[j].Contains("+") && !leftSide[j].Contains("-"))
                        leftSide[j] = leftSide[j].Insert(0, "+");
                }

                LeftSideEquations.Add("");
                LeftSideEquations[i] += string.Join("",leftSide);
                i++;
            }
        }

        /// <summary>
        /// ParseCoefficientMatrix Method for extracting the coefficient of the equation variables
        /// </summary>
        private void ParseCoefficientMatrix()
        {
            for (int i = 0; i < LeftSideEquations.Count; i++)
            {
                string[] polynomials = Split(LeftSideEquations[i]);
                foreach (string p in polynomials)
                    ParsePolynomial(p, i);
            }
        }

        /// <summary>
        /// Split Method returning an array of splitted polynomials
        /// </summary>
        /// <param name="polynomial"></param>
        /// <returns></returns>
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
            polynomials = newStr.Split(',');

            return polynomials;
        }

        /// <summary>
        /// ParsePolynomial Method for parsing the polynomial
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="i"></param>
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

        /// <summary>
        /// GetCoefficientMatrix Method returning the coefficient matrix of the equation
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// CoefficientParseCompletion Method for completing the coefficient matrix 
        /// </summary>
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

        /// <summary>
        /// GetCrammerMatrices Method returning the Cramer Matrices
        /// </summary>
        /// <returns></returns>
        private List<Matrix<double>> GetCramerMatrices()
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

        /// <summary>
        /// GetAugmentedMatrix Method returning the augmented matrix of the equation
        /// </summary>
        /// <returns></returns>
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