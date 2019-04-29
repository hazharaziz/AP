using Microsoft.VisualStudio.TestTools.UnitTesting;
using E1B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E1.Tests
{
    [TestClass()]
    public class BasicQuestionsTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            Human h = new Human("Hooman", 21);
            Assert.AreEqual("Hooman", h.Name);

            h = new Human("Mozhgan", 18);
            Assert.AreEqual("Mozhgan", h.Name);
        }

        [TestMethod()]
        public void HumanAgeTest()
        {
            IHasAge h = new Human("Hooman", 21);
            Assert.AreEqual(21, h.GetAge());

            h = new Human("Mozhgan", 18);
            Assert.AreEqual(18, h.GetAge());
        }

        [TestMethod()]
        public void SwapIntTest()
        {
            int a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void SwapdoubleTest()
        {
            double a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void SwaplongTest()
        {
            long a = 1, b = 2;
            BasicQuestions.Swap(ref a, ref b);
            Assert.AreEqual(a, 2);
            Assert.AreEqual(b, 1);
        }

        [TestMethod()]
        public void OddSumTest()
        {
            int[] nums = new int[] { 1, 5, 4, 3, 12 };
            Assert.AreEqual(9, BasicQuestions.OddSum(nums));

            nums = new int[] { 1, 5, 4, 3, 12, 1 };
            Assert.AreEqual(10, BasicQuestions.OddSum(nums));
        }
    }
}