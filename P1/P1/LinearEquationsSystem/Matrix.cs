using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P1
{
    public class Matrix<_Type> :
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            Rows = new Vector<_Type>[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                Rows[i] = new Vector<_Type>(columnCount);
            }
        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
            : this(rows.ToArray().Length, rows.ToArray()[0].Size)
        {
            for (int i = 0; i < rows.ToArray().Length; i++)
            {
                this.Add(rows.ToArray()[i]);
            }
        }

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public Vector<_Type> this[int index]
        {
            get => Rows[index];
            set => Rows[index] = value;
        }

        public _Type this[int row, int col]
        {
            get => Rows[row][col];
            set => Rows[row][col] = value;
        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            Matrix<_Type> newMatrix = new Matrix<_Type>(m1.RowCount, m1.ColumnCount);
            try
            {
                if (m1.RowCount != m2.RowCount || m1.ColumnCount != m2.ColumnCount)
                {
                    throw new InvalidOperationException();
                }
                for (int i = 0; i < m1.RowCount; i++)
                {
                    for (int j = 0; j < m1.ColumnCount; j++)
                    {
                        newMatrix[i][j] = (dynamic)m1[i][j] + (dynamic)m2[i][j];
                    }
                }
            }
            catch (InvalidOperationException) { throw; }
            return newMatrix;
        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {

            Matrix<_Type> newMatrix = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            try
            {
                if (m1.ColumnCount != m2.RowCount)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    for (int i = 0; i < m1.RowCount; i++)
                        for (int j = 0; j < m2.ColumnCount; j++)
                            for (int k = 0; k < m1.ColumnCount; k++)
                                newMatrix[i][j] += ((dynamic)m1[i][k] * (dynamic)m2[k][j]);
                }
            }
            catch (InvalidOperationException) { throw; }
            return newMatrix;
        }

        public static bool operator ==(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            return m1.Equals(m2);
        }

        public static bool operator !=(Matrix<_Type> m1, Matrix<_Type> m2)
            => !(m1 == m2);

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            for (int i = 0; i < RowCount; i++)
            {
                yield return Rows[i][col];
            }
        }


        protected Vector<_Type> GetColumn(int col) =>
            new Vector<_Type>(GetColumnEnumerator(col));

        /// <summary>
        /// Equals Method for checking the equality of two matrices
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Matrix<_Type> other)
            => (this.ToString() == (dynamic)other.ToString());

        /// <summary>
        /// getCofactor Method returning the cofactor of a double type matrix 
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="tempMatrix"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        private static void getCofactor(Matrix<double> matrix, Matrix<double> tempMatrix, int p, int q)
        {
            int i = 0; int j = 0; int n = matrix.RowCount;

            for (int row = 0; row < n; row++)
                for (int col = 0; col < n; col++)
                    if (row != p && col != q)
                    {
                        tempMatrix[i][j++] = matrix[row][col];

                        if (j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
        }

        /// <summary>
        /// Determinant Method is a static method for calculating the determinant of the double type matrices
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static double Determinant(Matrix<double> matrix, int size)
        {
            double Det = 0;
            int sign = 1;

            if (size == 1)
                return matrix[0][0];
            else
            {
                Matrix<double> temp = new Matrix<double>(size, size);
                for (int f = 0; f < size; f++)
                {
                    getCofactor(matrix, temp, 0, f);
                    Det += (sign * matrix[0][f] * Determinant(temp, size - 1));
                    sign *= -1;
                }
            }
            return Det;
        }


        /// <summary>
        /// Equals Method for checking the equality of two matrices
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
                => (this.ToString() == (dynamic)obj.ToString());

        /// <summary>
        /// GetHashCode Method for getting the hashcode of an object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();
            return code;
        }

        /// <summary>
        /// GetEnumerator Method iterating over an IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        /// <summary>
        /// GetEnumerator Method iterating over an IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        /// <summary>
        /// ToString Method for demonstrating the matrix 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "[\n";
            for (int i = 0; i < RowCount; i++)
            {
                if (i != RowCount - 1)
                    result += $"{Rows[i]},\n";
                else
                    result += $"{Rows[i]}\n";
            }
            result += "]";

            return result;
        }

        public Matrix<_Type> Copy(int rowCount, int colCount)
        {
            Matrix<_Type> copy = new Matrix<_Type>(rowCount, colCount);
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    copy[i][j] = this[i][j];
            return copy;
        }
    }
}