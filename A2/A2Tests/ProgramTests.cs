using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AssignPiTest()
        {
            double expectedResult = Math.PI;
            Program.AssignPi(out double pi);

            Assert.AreEqual(expectedResult, pi);

        }

        [TestMethod()]
        public void SquareTest()
        {
            int x = 2;
            int expectedNumber = 4;
            Program.Square(ref x);

            Assert.AreEqual(expectedNumber, x);
        }

        [TestMethod()]
        public void SwapTest()
        {
            int a = 4;
            int b = 5;
            Program.Swap(ref a, ref b);

            int expectedA = 5;
            int expectedB = 4;
            

            Assert.AreEqual(expectedA, a);
            Assert.AreEqual(expectedB, b);
        }

        [TestMethod()]
        public void SumTest()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            int expectedSum = 15;
            Program.Sum(out int functionalSum, arr);

            Assert.AreEqual(expectedSum, functionalSum);
            
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            int appendNumber = 6;

            int[] expectedArr = new int[] { 1, 2, 3, 4, 5, 6 };
            Program.Append(ref arr, appendNumber);

            CollectionAssert.AreEqual(expectedArr, arr);

        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] arr = new int[] { -4, -5, 2, -3, -1, 7 };

            int[] expectedArr = new int[] { 4, 5, 2, 3, 1, 7 };
            Program.AbsArray(ref arr);

            CollectionAssert.AreEqual(expectedArr, arr);

        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr2 = new int[] { 5, 4, 3, 2, 1 };
            int[] arr3 = new int[] { 6, 7, 8, 9, 10, 11, 23, 45 };
            int[] arr4 = new int[] { 15, 16, 17 };

            int[] expectedArr1 = new int[] { 5, 4, 3, 2, 1 };
            int[] expectedArr2 = new int[] { 1, 2, 3, 4, 5 };
            int[] expectedArr3 = new int[] { 15, 16, 17 };
            int[] expectedArr4 = new int[] { 6, 7, 8, 9, 10, 11, 23, 45 };

            Program.ArraySwap(ref arr1, ref arr2);
            Program.ArraySwap(ref arr3, ref arr4);

            CollectionAssert.AreEqual(expectedArr1, arr1);
            CollectionAssert.AreEqual(expectedArr2, arr2);
            CollectionAssert.AreEqual(expectedArr3, arr3);
            CollectionAssert.AreEqual(expectedArr4, arr4);


        }
    }
}