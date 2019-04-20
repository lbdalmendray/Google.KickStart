using System;
using System.Linq;
using EvenDigits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvenDigitsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Solution.Solve1("9999");
            Assert.AreEqual(result, 1111);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = Solution.Solve1("42");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = Solution.Solve1("11");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var result = Solution.Solve1("1");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var result = Solution.Solve1("2018");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod6()
        {
            for (int i = 0; i < 10; i++)
            {
                var result = Solution.Solve1(i.ToString());
                Assert.AreEqual(result, i%2 == 0 ? 0 : 1);
            }            
        }

        [TestMethod]
        public void TestMethod7()
        {
            for (int i = 11; i <= 100; i++)
            {
                var result = Solution.Solve1(i.ToString());

                Assert.AreEqual(result, SolveSlowly(i));
            }
        }

        [TestMethod]
        public void TestMethod8()
        {
            for (int i = 999 ; i <= 9999 ; i++)
            {
                var result = Solution.Solve1(i.ToString());

                Assert.AreEqual(result, SolveSlowly(i));
            }
        }

        private int SolveSlowly(int number)
        {
            int underResult = 0;
            int overResult = 0;
            int underNumber = number;
            int overNumber = number;

            while(hasOddDigit(underNumber))
            {
                underResult++;
                underNumber--;
            }

            while (hasOddDigit(overNumber))
            {
                overResult++;
                overNumber++;
            }

            return Math.Min(underResult, overResult);
        }

        private bool hasOddDigit(int number)
        {
            return number.ToString().ToCharArray().Any(d => int.Parse(d.ToString()) % 2 != 0);
        }
    }
}
