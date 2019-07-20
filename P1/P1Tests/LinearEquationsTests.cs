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
            Assert.AreEqual("No Solution", linearEquations[1].SolutionString);
            Assert.AreEqual("No Solution", linearEquations[2].SolutionString);
            Assert.AreEqual("x = -1.0 , y = 2.0 , z = 0.0 , t = 1.0", linearEquations[3].SolutionString);
            Assert.AreEqual("x = 2.0 , y = -1.3 , z = 1.8", linearEquations[4].SolutionString);
            Assert.AreEqual("No Unique Solution", linearEquations[5].SolutionString);
            Assert.AreEqual("No Unique Solution", linearEquations[6].SolutionString);
            Assert.AreEqual("No Solution", linearEquations[7].SolutionString);
            Assert.AreEqual("x = 0.4 , y = 1.8 , z = -2.0", linearEquations[8].SolutionString);
        }

        [TestMethod()]
        public void SolutionStateTest()
        {
            Assert.AreEqual(SolutionState.Unique, linearEquations[0].SolutionState);
            Assert.AreEqual(SolutionState.NoSolution, linearEquations[1].SolutionState);
            Assert.AreEqual(SolutionState.NoSolution, linearEquations[2].SolutionState);
            Assert.AreEqual(SolutionState.Unique, linearEquations[3].SolutionState);
            Assert.AreEqual(SolutionState.Unique, linearEquations[4].SolutionState);
            Assert.AreEqual(SolutionState.Infinite, linearEquations[5].SolutionState);
            Assert.AreEqual(SolutionState.Infinite, linearEquations[6].SolutionState);
            Assert.AreEqual(SolutionState.NoSolution, linearEquations[7].SolutionState);
            Assert.AreEqual(SolutionState.Unique, linearEquations[8].SolutionState);
        }

        [TestMethod()]
        public void LeftSideEquationsTest()
        {
            CollectionAssert.AreEqual(new List<string>() { "+2x" }, linearEquations[0].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x+y","+2x+y" }, linearEquations[1].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x+y+z","+x+z","+x+y" }, linearEquations[2].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x+y+z+t", "+x+y+t","+y+t+z","+x+y+3t" }, linearEquations[3].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x+y-z","+2y+2z","+x+y-z" }, linearEquations[4].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+x+3y+2z","+2x+y+4z","+x+2y+2z" }, linearEquations[5].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+x+2y-z", "+2x-y+2z", "+3x-4y+5z" }, linearEquations[6].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x-3y+4z","+12x+y-2z","+5x+2y-3z" }, linearEquations[7].LeftSideEquations);
            CollectionAssert.AreEqual(new List<string>() { "+2x+3y+3z", "+3x+5y+z","+4y+3z" }, linearEquations[8].LeftSideEquations);
        }


        [TestMethod()]
        public void RightSideVectorTest()
        {
            Assert.AreEqual(new Vector<double>(1) { -1 }, linearEquations[0].RightSideVector);
            Assert.AreEqual(new Vector<double>(2) { 0,1 }, linearEquations[1].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 0,1,2 }, linearEquations[2].RightSideVector);
            Assert.AreEqual(new Vector<double>(4) { 1,2,3,4 }, linearEquations[3].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 1,1,-1 }, linearEquations[4].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 1,2,1 }, linearEquations[5].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 4,3,2 }, linearEquations[6].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 2,5,2 }, linearEquations[7].RightSideVector);
            Assert.AreEqual(new Vector<double>(3) { 0,8,1 }, linearEquations[8].RightSideVector);
        }

        [TestMethod()]
        public void VariableCoefficientsTest()
        {
            CollectionAssert.AreEqual(new List<double>() { 2 }, linearEquations[0].VarCoefficients['x']);
            CollectionAssert.AreEqual(new List<double>() { 1,1 }, linearEquations[1].VarCoefficients['y']);
            CollectionAssert.AreEqual(new List<double>() { 1,1,0 }, linearEquations[2].VarCoefficients['z']);
            CollectionAssert.AreEqual(new List<double>() { 1,1,1,3 }, linearEquations[3].VarCoefficients['t']);
            CollectionAssert.AreEqual(new List<double>() { 2,0,1 }, linearEquations[4].VarCoefficients['x']);
            CollectionAssert.AreEqual(new List<double>() { 3,1,2 }, linearEquations[5].VarCoefficients['y']);
            CollectionAssert.AreEqual(new List<double>() { -1,2,5 }, linearEquations[6].VarCoefficients['z']);
            CollectionAssert.AreEqual(new List<double>() { 2,12,5 }, linearEquations[7].VarCoefficients['x']);
            CollectionAssert.AreEqual(new List<double>() { 3,5,4 }, linearEquations[8].VarCoefficients['y']);
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
        public void SplitEquationTests()
        {
            CollectionAssert.AreEqual(new string[] { "2x", "+x^2", "+x" }, diagramEquations[0].Split(diagramEquations[0].EquationString));
            CollectionAssert.AreEqual(new string[] { "x", "+1" }, diagramEquations[1].Split(diagramEquations[1].EquationString));
            CollectionAssert.AreEqual(new string[] { "x^3", "+x^4", "+x^5","+2x","+1" }, diagramEquations[2].Split(diagramEquations[2].EquationString));
            CollectionAssert.AreEqual(new string[] { "3x", "+4x^2", "+5x^3" }, diagramEquations[3].Split(diagramEquations[3].EquationString));
        }

        [TestMethod()]
        public void ParseEquationTest()
        {
            Assert.AreEqual(10, diagramEquations[0].ParseNormalEquation(2, diagramEquations[0].EquationString));
            Assert.AreEqual(18, diagramEquations[0].ParseNormalEquation(3, diagramEquations[0].EquationString));
            Assert.AreEqual(0, diagramEquations[0].ParseNormalEquation(0, diagramEquations[0].EquationString));

            Assert.AreEqual(11, diagramEquations[1].ParseNormalEquation(10, diagramEquations[1].EquationString));
            Assert.AreEqual(221, diagramEquations[1].ParseNormalEquation(220, diagramEquations[1].EquationString));
            Assert.AreEqual(41, diagramEquations[1].ParseNormalEquation(40, diagramEquations[1].EquationString));

            Assert.AreEqual(6, diagramEquations[2].ParseNormalEquation(1, diagramEquations[2].EquationString));
            Assert.AreEqual(-2, diagramEquations[2].ParseNormalEquation(-1, diagramEquations[2].EquationString));
            Assert.AreEqual(61, diagramEquations[2].ParseNormalEquation(2, diagramEquations[2].EquationString));

            Assert.AreEqual(5430, diagramEquations[3].ParseNormalEquation(10, diagramEquations[3].EquationString));
            Assert.AreEqual(62, diagramEquations[3].ParseNormalEquation(2, diagramEquations[3].EquationString));
            Assert.AreEqual(12, diagramEquations[3].ParseNormalEquation(1, diagramEquations[3].EquationString));
        }
    }

}