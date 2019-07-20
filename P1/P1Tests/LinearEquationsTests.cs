using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace P1.Tests
{
    [TestClass()]
    public class LinearEquationsTests
    {
        LinearEquations linearEquations;

        [TestMethod()]
        public void LinearEquationsTest()
        {
            linearEquations = new LinearEquations("2x=1,2y=1");
            Assert.AreEqual("x = 0.5 , y = 0.5", linearEquations.SolutionString);
            Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            Assert.AreEqual(new Vector<double>(2) { 1, 1 }, linearEquations.RightSideVector);

            linearEquations = new LinearEquations("2x+3y = 0 , 3x+ 2y =1");
            Assert.AreEqual($"x = 0.6 , y = -0.4", linearEquations.SolutionString);
            Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            CollectionAssert.AreEqual(new List<string>() { "2x+3y ", " 3x+ 2y " }, linearEquations.LeftSideEquations);

            linearEquations = new LinearEquations("2x+3y+3z=0, 3x+5y+z=8,4y+3z=1");
            Assert.AreEqual("x = 0.4 , y = 1.8 , z = -2.0", linearEquations.SolutionString);
            Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            CollectionAssert.AreEqual(new List<double>() { 2, 3, 0 }, linearEquations.VarCoefficients['x']);

            linearEquations = new LinearEquations("2x - 3y + 4z = 2\n" +
                                                  "12x + y -2z = 5\n" +
                                                  "5x + 2y-3z=2");
            Assert.AreEqual("No Solution", linearEquations.SolutionString);
            Assert.AreEqual(SolutionState.NoSolution, linearEquations.SolutionState);
            Assert.IsTrue(new Matrix<double>(3, 3) {
                            new Vector<double>(3){2,-3,4 },
                            new Vector<double>(3){12,1,-2 },
                            new Vector<double>(3){5,2,-3 } } == linearEquations.CoefficientMatrix);

            linearEquations = new LinearEquations("x + 2y-z=4, 2x-y+2z=3, 3x-4y+5z=2");
            Assert.AreEqual("No Unique Solution", linearEquations.SolutionString);
            Assert.AreEqual(SolutionState.Infinite, linearEquations.SolutionState);
            Assert.IsTrue(new Vector<double>(3) { 3, 4, 2 } != linearEquations.RightSideVector);
        }
    }

    [TestClass()]
    public class DiagramEquationTest
    {
        DiagramEquation equation;

        [TestMethod()]
        public void NormalEquationTests()
        {
            equation = new DiagramEquation("x^2 + 2 + x", EquationType.Normal);
            CollectionAssert.AreEqual(new string[] { "x^2", "+2", "+x" }, equation.Split(equation.EquationString));
            Assert.AreEqual(4, equation.ParseNormalEquation(1, equation.EquationString));
            Assert.AreEqual(120, equation.Factorial(5));
        }
    }

}