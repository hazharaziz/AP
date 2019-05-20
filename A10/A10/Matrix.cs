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
            Rows = new Vector<_Type>[RowCount];
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            throw new NotImplementedException();
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
    }
}