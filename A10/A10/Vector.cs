using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    /// <summary>
    /// A vector of numbers. Implement vector addition and multiplication.
    /// </summary>
    /// <typeparam name="_Type"></typeparam>
    public class Vector<_Type> : 
        IEnumerable<_Type>, IEquatable<Vector<_Type>>
        where _Type: IEquatable<_Type>        
    {
        /// <summary>
        /// Vector data
        /// </summary>
        protected readonly _Type[] Data;

        /// <summary>
        /// Add index. Only used for collection initialization.
        /// </summary>
        protected int AddIndex = 0;

        /// <summary>
        /// Vector Size
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Add method to allow collection initialization.
        /// </summary>
        /// <param name="v"></param>
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
        }

        /// <summary>
        /// Create a new Vector
        /// </summary>
        /// <param name="length">Vector length</param>
        public Vector(int length)
        {
            this.Data = new _Type[length];
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {

        }

        /// <summary>
        /// Constructor for IEnumerable
        /// </summary>
        /// <param name="list">IEnumerable of _Type</param>
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {
            
        }

        /// <summary>
        /// Accessor for data elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _Type this[int index]
        {
            get => Data[index];
            set => Data[index] = value;
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            dynamic vector1 = v1;
            dynamic vector2 = v2;
            dynamic newVector = new Vector<_Type>(v1.Size);

            for (int i = 0; i < newVector.Size; i++)
            {
                newVector[i] += v1[i];
                newVector[i] += v2[i];
            }

            return newVector;
        }

        /// <summary>
        /// Inner product of two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            throw new NotImplementedException();
           
        }



        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>whether v1 is equal to v2</returns>
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
            => true; //TODO
      

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>v1 not equal to v2</returns>
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
            => true; //TODO

        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            return true;
        }

        /// <summary>
        /// Implementing IEquatable interface
        /// </summary>
        /// <param name="other">another vector</param>
        /// <returns>whether other vector is equal to this vector</returns>
        public bool Equals(Vector<_Type> other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public IEnumerator<_Type> GetEnumerator()
        {
            throw new NotImplementedException();
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
