using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircularLoop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCircularArray
{
    [TestClass]
     public class TestMergeSort
    {

        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = new int[] { 23,5,6,1,2,33,99,45,7,6,34 };
            MergeSort mergeSortClass = new MergeSort();
            int[] actualArray= mergeSortClass.Divide(arr);

            int[] expectedArray = new int[] {1,2,5,6,6,7,23,33,34,45,99 };

            var actualString = String.Join(" ", actualArray);
            var exptedString = String.Join(" ", expectedArray); 

            Assert.AreEqual(actualString, exptedString);
        }
    }
}
