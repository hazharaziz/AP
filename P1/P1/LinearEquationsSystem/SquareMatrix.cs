using System;
using System.Collections.Generic;
using System.IO;

namespace P1
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        /// <summary>
        /// SquareMatrix Class Constructor
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public SquareMatrix(int rowCount, int columnCount) : base(rowCount, columnCount) { }

        /// <summary>
        /// Equals Method for checking the equality of two square matrices
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
            => base.Equals(obj);

        /// <summary>
        /// GetHashCode Method for getting the hashcode of an object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
            => base.GetHashCode();

        /// <summary>
        /// ToString Method for demonstrating the square matrix 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => base.ToString();
    }
}