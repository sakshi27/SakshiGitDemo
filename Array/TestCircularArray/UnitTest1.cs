using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircularLoop;

namespace TestCircularArray
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyIfArrayIsSorted()
        {
            //No circular traverse happened
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int position = Program.CircularPosition(arr);
            Assert.AreEqual(0, position);
        }

        [TestMethod]
        public void VerifyIfArrayIsEMpty()
        {
            int[] arr = new int[] { };
            int position = Program.CircularPosition(arr);
            Assert.AreEqual(0, position);
        }

        [TestMethod]
        public void VerifyIfarrayHas1Element()
        {
            int[] arr = new int[] { 1 };
            int position = Program.CircularPosition(arr);
            Assert.AreEqual(0, position);
        }

        [TestMethod]
        public void VerifyPositionIsFirst()
        {
            int[] arr = new int[] {9,1,2,3,4,5,6,7,8 };
            int position = Program.CircularPosition(arr);
            Assert.AreEqual(0, position);
        }

        [TestMethod]
        public void VerifyPositionIsLast()
        {
            int[] arr = new int[] { 2,3,4,5,6,7,8,9,1 };
            int position = Program.CircularPosition(arr);
            Assert.AreEqual(arr.Length-1, position);
        }
        // array is null
        //Has one element in array
        //If the array is soreted fully

    }
}
