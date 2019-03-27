using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training;

namespace TrainingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int result = Solution.Solve(new int[] { 3, 1, 9, 100 }, 3);
            Assert.AreEqual(result, 14);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int result = Solution.Solve(new int[] { 5 ,5, 1, 2, 3, 4 }, 2);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int result = Solution.Solve(new int[] { 7 , 7, 1, 7, 7 }, 5);
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int result = Solution.Solve(new int[] { 1, 100 }, 1);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int result = Solution.Solve(new int[] { 1, 100 }, 2);
            Assert.AreEqual(result, 99);
        }
    }
}
