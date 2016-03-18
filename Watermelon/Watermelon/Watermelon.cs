using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Watermelon
{
    [TestClass]
    public class Watermelon
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(true, CheckWatermelonKg(20));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(false, CheckWatermelonKg(21));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(false, CheckWatermelonKg(2));
        }
        Boolean CheckWatermelonKg(int watermelonWeight)
        {
            if (watermelonWeight == 2)
                return false;
            else if (watermelonWeight % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
