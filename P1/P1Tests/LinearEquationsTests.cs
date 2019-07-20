using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace P1Tests
{
    [TestClass()]
    public class LinearEquationsTests
    {
        public LinearEquations[] linearEquations = new LinearEquations[]
        {
            new LinearEquations("2x+1 = 0"),
            new LinearEquations("2x+y = 0,2x+y= 1"),
            new LinearEquations("2x+y+z = 0,x+z=1,x+y=2"),
            new LinearEquations("2x+y+z+t = 1, x+y+t=2,y+t+z=3,x+y+3t= 4"),
            new LinearEquations("2x+y= z+1,2y+2z=1,x+y+1 = z"),
            new LinearEquations("x+3y+2z=1\n2x+y+4z=2\nx+2y+2z=1"),
            new LinearEquations("x + 2y-z=4, 2x-y+2z=3, 3x-4y+5z=2"),
            new LinearEquations("2x - 3y + 4z = 2\n12x + y -2z = 5\n5x + 2y-3z=2"),
            new LinearEquations("2x+3y+3z=0, 3x+5y+z=8,4y+3z=1")
        };


        [TestMethod()]
        public void SolutionStringTest()
        {
            
            Assert.AreEqual("x = -0.5", linearEquations[0].SolutionString);
            //Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            //Assert.AreEqual(new Vector<double>(2) { 1, 1 }, linearEquations.RightSideVector);

            
            Assert.AreEqual("No Solution", linearEquations[1].SolutionString);
            //Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            //CollectionAssert.AreEqual(new List<string>() { "2x+3y ", " 3x+ 2y " }, linearEquations.LeftSideEquations);

            Assert.AreEqual("No Solution", linearEquations[2].SolutionString);
            Assert.AreEqual("x = -1.0 , y = 2.0 , z = 0.0 , t = 1.0", linearEquations[3].SolutionString);
            Assert.AreEqual("x = 2.0 , y = -1.3 , z = 1.8", linearEquations[4].SolutionString);
            Assert.AreEqual("No Unique Solution", linearEquations[5].SolutionString);
            Assert.AreEqual("No Unique Solution", linearEquations[6].SolutionString);
            Assert.AreEqual("No Solution", linearEquations[7].SolutionString);
            Assert.AreEqual("x = 0.4 , y = 1.8 , z = -2.0", linearEquations[8].SolutionString);




            //Assert.AreEqual("x = 0.4 , y = 1.8 , z = -2.0", linearEquations.SolutionString);
            //Assert.AreEqual(SolutionState.Unique, linearEquations.SolutionState);
            //CollectionAssert.AreEqual(new List<double>() { 2, 3, 0 }, linearEquations.VarCoefficients['x']);

            //Assert.AreEqual("No Solution", linearEquations.SolutionString);
            //Assert.AreEqual(SolutionState.NoSolution, linearEquations.SolutionState);
            //Assert.IsTrue(new Matrix<double>(3, 3) {
            //                new Vector<double>(3){2,-3,4 },
            //                new Vector<double>(3){12,1,-2 },
            //                new Vector<double>(3){5,2,-3 } } == linearEquations.CoefficientMatrix);

            //Assert.AreEqual("No Unique Solution", linearEquations.SolutionString);
            //Assert.AreEqual(SolutionState.Infinite, linearEquations.SolutionState);
            //Assert.IsTrue(new Vector<double>(3) { 3, 4, 2 } != linearEquations.RightSideVector);
        }
    }

    [TestClass()]
    public class DiagramEquationTest
    {
        public DiagramEquation[] diagramEquations = new DiagramEquation[]
        {
            new DiagramEquation("2x + x^2 + x",EquationType.Normal),
            new DiagramEquation("x+1",EquationType.Normal),
            new DiagramEquation("x^3 + x^4 + x^5 + 2x + 1", EquationType.Normal),
            new DiagramEquation("3x + 4x^2 + 5x^3",EquationType.Normal)
        };


        [TestMethod()]
        public void NormalEquationTests()
        {
            //equation = new DiagramEquation("x^2 + 2 + x", EquationType.Normal);
            //CollectionAssert.AreEqual(new string[] { "x^2", "+2", "+x" }, equation.Split(equation.EquationString));
            //Assert.AreEqual(4, equation.ParseNormalEquation(1, equation.EquationString));
            //Assert.AreEqual(120, equation.Factorial(5));
        }
    }

}