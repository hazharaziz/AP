using System;
using System.Collections.Generic;
using System.IO;

namespace A10
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(int rowCount, int columnCount) : base(rowCount, columnCount) { }

        public override bool Equals(object obj)
            => base.Equals(obj);

        public override int GetHashCode()
            => base.GetHashCode();

        public override string ToString()
            => base.ToString();






    }
}