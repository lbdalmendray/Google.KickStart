using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionTemplate;

namespace StableWallTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] originInput = new string[]
            {
                "ZOAAMM",
                "ZOAOMM",
                "ZOOOOM",
                "ZZZZOM"
            };
            char[,] input = new char[originInput.Length, originInput[0].Length];
            for (int i = 0; i < originInput.Length; i++)
            {
                for (int j = 0; j < originInput[0].Length; j++)
                {
                    input[i, j] = originInput[i][j];
                }
            }


            var result = Solution.Solve(input);
            Assert.AreEqual(result, "ZOAM");
        }

        [TestMethod]
        public void TestMethod2()
        {
            string[] originInput = new string[]
            {
                "XXOO",
                "XFFO",
                "XFXO",
                "XXXO"
            };
            char[,] input = new char[originInput.Length, originInput[0].Length];
            for (int i = 0; i < originInput.Length; i++)
            {
                for (int j = 0; j < originInput[0].Length; j++)
                {
                    input[i, j] = originInput[i][j];
                }
            }


            var result = Solution.Solve(input);
            Assert.AreEqual(result, "-1");
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] originInput = new string[]
            {
                "XXX",
                "XPX",
                "XXX",
                "XJX",
                "XXX"
            };
            char[,] input = new char[originInput.Length, originInput[0].Length];
            for (int i = 0; i < originInput.Length; i++)
            {
                for (int j = 0; j < originInput[0].Length; j++)
                {
                    input[i, j] = originInput[i][j];
                }
            }


            var result = Solution.Solve(input);
            Assert.AreEqual(result, "-1");
        }

        [TestMethod]
        public void TestMethod4()
        {
            string[] originInput = new string[]
            {
                "AAABBCCDDE",
                "AABBCCDDEE",
                "AABBCCDDEE"
            };
            char[,] input = new char[originInput.Length, originInput[0].Length];
            for (int i = 0; i < originInput.Length; i++)
            {
                for (int j = 0; j < originInput[0].Length; j++)
                {
                    input[i, j] = originInput[i][j];
                }
            }


            var result = Solution.Solve(input);
            Assert.AreEqual(result, "EDCBA");
        }
    }

}
