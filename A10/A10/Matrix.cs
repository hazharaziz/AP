using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace A10
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
        {

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
            dynamic matrix1 = m1;
            dynamic matrix2 = m2;
            dynamic newMatrix = new Matrix<_Type>(m1.RowCount, m1.ColumnCount);

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
                        newMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
                    }
                }
            }
            catch(InvalidOperationException)
            {
                throw;
            }
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
            dynamic matrix1 = m1;
            dynamic matrix2 = m2;
            dynamic newMatrix = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);

            try
            {
                if (matrix1.ColumnCount != matrix2.RowCount)
                {
                    throw new InvalidOperationException();
                }

                for (int i = 0; i < m1.RowCount; i++)
                {
                    for (int j = 0; j < m2.ColumnCount; j++)
                    {
                        for (int k = 0; k < m1.ColumnCount; k++)
                        {
                            newMatrix[i][j] += (matrix1[i][k] * matrix2[k][j]);
                        }
                    }
                }   
            }
            catch(InvalidOperationException)
            {
                throw;
            }

            return newMatrix;
        }

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            throw new NotImplementedException();
        }

        protected Vector<_Type> GetColumn(int col) =>
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            return true;
        }

        public override bool Equals(object obj)
        {
            return true;
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        { 
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

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
    }
}