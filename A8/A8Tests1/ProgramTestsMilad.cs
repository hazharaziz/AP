using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void HumanTest1()
        {
            Human human = new
                Human(
                    "FirstName",
                    "LastName",
                    DateTime.Today,
                    123);
        }

        [TestMethod()]
        public void PlusOperatorTest()
        {
            // Arrange
            string expectedFirstName = "ChildFirstName";
            string expectedLastName = "ChildLastName";
            DateTime expectedBirthday = DateTime.Today;
            double expectedHeight = 30;

            //Act
            Human human1 = new
                Human(
                    "FirstName1",
                    "LastName1",
                    DateTime.MaxValue,
                    123);
            Human human2 = new
                Human(
                    "FirstName2",
                    "LastName2",
                    DateTime.MinValue,
                    321);

            Human human3 = human1 + human2;

            // Assert
            Assert.AreEqual(expectedFirstName, human3.FirstName);
            Assert.AreEqual(expectedLastName, human3.LastName);
            Assert.AreEqual(expectedBirthday, human3.BirthDate);
            Assert.AreEqual(expectedHeight, human3.Height);
        }

        [TestMethod()]
        public void ComparisonOperatorsTest1()
        {
            // Act
            Human human1 = new
                Human("FirstName1",
                    "LastName1",
                    DateTime.MaxValue,
                    123);
            Human human2 = new
                Human(
                    "FirstName2",
                    "LastName2",
                    DateTime.MinValue,
                    321);

            // Assert
            Assert.AreEqual(true, human1 < human2);
            Assert.AreEqual(true, human1 <= human2);

            Assert.AreEqual(false, human1 > human2);
            Assert.AreEqual(false, human1 >= human2);
        }

        [TestMethod()]
        public void ComparisonOperatorsTest2()
        {
            // Act
            Human human1 = new
                Human(
                    "FirstName1",
                    "LastName2",
                    DateTime.MaxValue,
                    123);
            Human human2 = new
                Human(
                    "FirstName2",
                    "LastName2",
                    DateTime.MinValue,
                    321);
            Human human3 = new Human("" +
                                     "FirstName3",
                "LastName2",
                DateTime.MaxValue,
                231);

            // Assert
            Assert.AreEqual(false, human1 == human2);
            Assert.AreEqual(true, human1 == human3);

            Assert.AreEqual(true, human1 != human2);
            Assert.AreEqual(false, human1 != human3);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            // Act
            Human human1 = new
                Human(
                    "FirstName1",
                    "LastName1",
                    DateTime.MaxValue,
                    123);

            Human human2 = new
                Human(
                    "FirstName2",
                    "LastName2",
                    DateTime.MinValue,
                    321);

            Human human3 = new
                Human(
                    "FirstName3",
                    "LastName2",
                    DateTime.MaxValue,
                    231);

            Human human4 = new
                Human(
                    "FirstName1",
                    "LastName1",
                    DateTime.MaxValue,
                    123);

            // Assert
            Assert.AreEqual(false, human1.Equals(human2));
            Assert.AreEqual(false, human1.Equals(human3));
            Assert.AreEqual(false, human1.Equals(human3));
            Assert.AreEqual(true, human1.Equals(human4));
            
        }
    }
}