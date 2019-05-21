using Microsoft.VisualStudio.TestTools.UnitTesting;
using A10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10.Tests
{
    [TestClass()]
    public class SquareMatrixTests
    {
        [TestMethod()]
        public void SquareMatrixTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){1,11,21},
                new Vector<int>(3){2,12,22},
                new Vector<int>(3){3,13,23}
            };

            for (int i = 0; i < sm1.RowCount; i++)
            {
                for (int j = 0; j < sm1.ColumnCount; j++)
                {
                    Assert.AreEqual(
                        (i + 1) + 10 * j, sm1[i, j]);
                }
            }
        }

        [TestMethod()]
        public void EqualsTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,4},
                new Vector<int>(2){3,5}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,4},
                new Vector<int>(2){3,5}
            };

            SquareMatrix<int> sm3 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){1,2,2},
                new Vector<int>(3){2,1,3}
            };

            SquareMatrix<int> sm4 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){3,4,4},
                new Vector<int>(3){2,6,6}
            };

            Assert.AreEqual(sm1, sm2);
            Assert.AreNotEqual(sm1, sm3);

            Assert.IsTrue(sm1 == sm2);
            Assert.IsFalse(sm2 == sm4);

            Assert.AreNotEqual(sm3, sm4);
            Assert.IsFalse(sm3 == sm4);
            Assert.IsTrue(sm3 != sm4);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){2,3},
                new Vector<int>(2){3,4}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){2,3},
                new Vector<int>(2){3,4}
            };

            Assert.AreEqual(sm1.GetHashCode(), sm2.GetHashCode());

            SquareMatrix<int> sm3 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){3,2,4},
                new Vector<int>(3){4,5,6},
                new Vector<int>(3){1,6,7}
            };

            SquareMatrix<int> sm4 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){1,4,5},
                new Vector<int>(3){3,5,6},
                new Vector<int>(3){7,8,9}
            };

            Assert.AreNotEqual(sm3.GetHashCode(), sm4.GetHashCode());
        }

        [TestMethod()]
        public void SquareMatrixToStringTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){2,3},
                new Vector<int>(2){3,4}
            };

            Assert.AreEqual("[\n[2,3],\n[3,4]\n]", sm1.ToString());
        }

        [TestMethod()]
        public void AddTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){0,1},
                new Vector<int>(2){1,0}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){0,1}
            };

            var sm3 = sm1 + sm2;

            for (int i = 0; i < sm1.RowCount; i++)
            {
                for (int j = 0; j < sm1.ColumnCount; j++)
                {
                    Assert.AreEqual(1, sm3[i][j]);
                }
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddExceptionTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){0,1},
                new Vector<int>(2){1,0}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){1,4,5},
                new Vector<int>(3){3,5,6},
                new Vector<int>(3){7,8,9}
            };

            var sm3 = sm1 + sm2;
        }

        [TestMethod()]
        public void IEnumerable()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){0,1,2},
                new Vector<int>(3){3,4,5},
                new Vector<int>(3){6,7,8}
            };

            int index = 0;
            foreach (var vec in sm1)
                foreach (var item in vec)
                    Assert.AreEqual(index++, item);
        }

        [TestMethod()]
        public void MultiAddTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,4},
                new Vector<int>(2){3,5}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,4},
                new Vector<int>(2){3,5}
            };

            SquareMatrix<int> sm3 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){8,4},
                new Vector<int>(2){3,9}
            };

            var sm4 = sm1 + sm2 + sm3;
            Assert.AreEqual(new Vector<int>(2) { 10, 12 }, sm4[0]);
            Assert.AreEqual(new Vector<int>(2) { 9, 19 }, sm4[1]);
        }

        [TestMethod()]
        public void MultiExpressionTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){1,1}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){0,1}
            };

            SquareMatrix<int> sm3 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,1},
                new Vector<int>(2){1,0}
            };

            SquareMatrix<int> sm4 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){0,1},
                new Vector<int>(2){0,0}
            };

            var sm5 = sm1 * (sm2 + sm3) + sm2 * (sm1 + sm3);

            Assert.AreEqual(new Vector<int>(2) { 4, 2 }, sm5[0]);
            Assert.AreEqual(new Vector<int>(2) { 5, 3 }, sm5[1]);
        }

        [TestMethod()]
        public void MultiMultiplyTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){1,1}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){0,1}
            };

            SquareMatrix<int> sm3 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,1},
                new Vector<int>(2){1,0}
            };

            var sm4 = (sm1 * sm2) * sm3;

            Assert.AreEqual(new Vector<int>(2) { 1, 1 }, sm4[0]);
            Assert.AreEqual(new Vector<int>(2) { 2, 1 }, sm4[1]);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultiplyException()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,0},
                new Vector<int>(2){1,1}
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(3, 3)
            {
                new Vector<int>(3){1,2,3},
                new Vector<int>(3){4,5,6},
                new Vector<int>(3){7,8,9}
            };

            var sm3 = sm1 + sm2;
        }

        [TestMethod()]
        public void MultiplyTestLong()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(5, 5)
            {
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5))
            };

            SquareMatrix<int> sm2 = new SquareMatrix<int>(5, 5)
            {
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5)),
                new Vector<int>(Enumerable.Repeat(1,5))
            };

            var sm3 = sm1 * sm2;

            Assert.AreEqual(5, sm3[0, 0]);
            Assert.AreEqual(5, sm3[0, 4]);
        }

        [TestMethod()]
        public void AccessorTest()
        {
            SquareMatrix<int> sm1 = new SquareMatrix<int>(2, 2)
            {
                new Vector<int>(2){1,1},
                new Vector<int>(2){1,1}
            };

            Assert.AreEqual(new Vector<int>(2) { 1, 1 }, sm1[0]);
            Assert.AreEqual(new Vector<int>(2) { 1, 1 }, sm1[1]);

            foreach (var vec in sm1)
                foreach (var item in vec)
                    Assert.AreEqual(1, item);
        }

    }
}