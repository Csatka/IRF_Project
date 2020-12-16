using LZUJ9F_project;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class FormTest
    {
        [Test,
            TestCase(new int[] { 1, 2, 3, 4, 5 }, true),
            TestCase(new int[] { 1, 1, 3, 4, 5 }, false),
            TestCase(new int[] { 1, 1, 3, 3, 5 }, false),
            TestCase(new int[] { 1, 1, 1, 1, 1 }, false)
            ]
        public void TestCheckWinningNumbers(int[] winnum, bool expectedResult)
        {
            var form1 = new Form1();
            var actualResult = form1.CheckWinningNumbers(winnum);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
