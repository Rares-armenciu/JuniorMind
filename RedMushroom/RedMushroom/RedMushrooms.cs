using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedMushrooms
{
    [TestClass]
    public class RedMushrooms
    {
        [TestMethod]
        public void TestMethod1()
        {
            int RedMushrooms = CalculateRedMushrooms(22, 10);
            Assert.AreEqual(20, RedMushrooms);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int RedMushrooms = CalculateRedMushrooms(24, 7);
            Assert.AreEqual(21, RedMushrooms);
        }
        int CalculateRedMushrooms(int TotalMushrooms, int MushroomDifference)
        {
            return TotalMushrooms*MushroomDifference/(MushroomDifference+1);
        }
    }
}
