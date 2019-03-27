using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcels;

namespace ParcelsTest
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = new int[,]
            {
                { 1,0,1},
                { 0,0,0 },
                { 1,0,1 }
            };

            int result = Solution.Solve(convert(input));
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = new int[,]
            {
                { 11}
            };

            int result = Solution.Solve(convert(input));
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = new int[,]
            {
                {1,0,0,0,1 },
                { 0,0,0,0,0 }, 
                { 0,0,0,0,0 },
                { 0,0,0,0,0},
                { 1,0,0,0,1}
                
            };

            int result = Solution.Solve(convert(input));
            Assert.AreEqual(result, 2);
        }

        public bool[,] convert(int[,] input)
        {
            bool[,] result = new bool[input.GetLength(0), input.GetLength(1)];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    result[i, j] = input[i, j] == 1;
                }
            }

            return result;
        }
    }

    
}
