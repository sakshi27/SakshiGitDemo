using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircularLoop;
using System.Drawing;
using System.Collections.Generic;

namespace TestCircularArray
{
    [TestClass]
    public class findSum
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            List<Point> result= Program.findSumOccurance(arr, 1);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            List<Point> result = Program.findSumOccurance(arr, 8);

            List<Point> expectedResult = new List<Point>();
            expectedResult.Add(new Point(0, 6));
            expectedResult.Add(new Point(1, 5));
            expectedResult.Add(new Point(2, 4));
            Assert.AreEqual(expectedResult.Count, result.Count);
        }

        [TestMethod]
        public void TestNotes()
        {
            int value = 45111;
            List<Program.Note> result = Program.CountCurrency(value);

        }

        [TestMethod]
        public void NegativeValues()
        {
            int value = -45111;
            List<Program.Note> result = Program.CountCurrency(value);

        }
    }
}
