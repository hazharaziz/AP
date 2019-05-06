using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using HumanTests;

namespace A8.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            string expectedResult = "John";
            string functionalResult = TestData.John.FirstName;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = "Smith";
            functionalResult = TestData.Ava.LastName;
            Assert.AreEqual(expectedResult, functionalResult);

            DateTime expectedDate = new DateTime(1991, 3, 6);
            DateTime functionalDate = TestData.Jack.BirthDate;
            Assert.AreEqual(expectedResult, functionalResult);

            double expectedHeight = 174;
            double functionalHeight = TestData.Emma.Height;
            Assert.AreEqual(expectedResult, functionalResult);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            bool expctedResult = false;
            bool functionalResult = TestData.John.Equals(TestData.Emma);
            Assert.AreEqual(expctedResult, functionalResult);

            expctedResult = true;
            functionalResult = TestData.Liam.Equals(TestData.Jack);
            Assert.AreNotEqual(expctedResult, functionalResult);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            int expectedHash = -134218245;
            int functionalHash = TestData.John.GetHashCode();
            Assert.AreEqual(expectedHash, functionalHash);

            expectedHash = -536871043;
            functionalHash = TestData.Amelia.GetHashCode();
            Assert.AreEqual(expectedHash, functionalHash);
        }

        [TestMethod()]
        public void OperatorOverloadingTest()
        {
            //plus operator
            string expectedFirstName = "ChildFirstName";
            string functionalFirstName = TestData.Harry.FirstName;
            Assert.AreEqual(expectedFirstName, functionalFirstName);

            string expectedLastName = "ChildLastName";
            string functonalLastName = TestData.Oscar.LastName;
            Assert.AreEqual(expectedLastName, functonalLastName);

            DateTime expectedDate = DateTime.Today;
            DateTime functionalDate = TestData.James.BirthDate;
            Assert.AreEqual(expectedDate, functionalDate);

            double expectedHeight = 30;
            double functionalHeight = TestData.Oscar.Height;
            Assert.AreEqual(expectedHeight, functionalHeight);

            //age comparison
            bool expectedResult = true;
            bool functionalResult = TestData.Amelia < TestData.Jack;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = true;
            functionalResult = TestData.Emma > TestData.Ava;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = true;
            functionalResult = TestData.Amelia <= TestData.John;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = false;
            functionalResult = TestData.Ava >= TestData.Amelia;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = false;
            functionalResult = TestData.John == TestData.Liam;
            Assert.AreEqual(expectedResult, functionalResult);

            expectedResult = true;
            functionalResult = TestData.Emma == TestData.James;
            Assert.AreNotEqual(expectedResult, functionalResult);
        }
    }
}