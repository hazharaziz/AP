using Microsoft.VisualStudio.TestTools.UnitTesting;
using A0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {

            long expectedResult = 4;
            long functionResult = Program.Add(n1:1,n2:3);
            Assert.AreEqual(expectedResult, functionResult);
            
            

        }

        [TestMethod()]
        public void SubtractTest()
        {
            long expectedResult = -2;
            long functionResult = Program.Subtract(n1: 1, n2: 3);
            Assert.AreEqual(expectedResult, functionResult);
            
        }

        [TestMethod()]
        public void ProductTest()
        {
            long expectedResult = 3;
            long functionResult = Program.Product(n1: 1, n2: 3);
            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod()]
        public void DivideTest()
        {
            double expectedResult = 1;
            double functionResult = Program.Divide(n1: 1, n2: 1);
            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod()]
        public void SqrtTest()
        {
            double expectedResult = 1;
            double functionResult = Program.Sqrt(n1: 1);
            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod()]
        public void factorialTest()
        {
            long expectedResult = 1;
            long functionResult = Program.factorial(n: 1);
            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod()]
        public void NegateTest()
        {
            long expectedResult = -1;
            long functionResult = Program.Negate(n: 1);
            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod()]
        public void SquareTest()
        {
            long expectedResult = 1;
            long functionResult = Program.Square(n: 1);
            Assert.AreEqual(expectedResult, functionResult);
        }
    }
}