using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CircularLoop;

namespace TestCircularArray
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            CircularLoop.CountMinSteps obj = new CountMinSteps();
            int[] targetArray = new int[] { 2, 3 };
            int result= obj.countMinSteps(targetArray);

            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            CircularLoop.CountMinSteps obj = new CountMinSteps();
            int[] targetArray = new int[] { 2, 3 };
            int result = obj.CountMinSteps2(targetArray);

            Assert.AreEqual(result, 4);
        }
    }
}
