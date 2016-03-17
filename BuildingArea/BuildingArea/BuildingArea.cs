using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuildingArea
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            float areaOfBuilding = CalculateAreaOfBuilding(0, 0, 2, 0, 1 , 2);
            Assert.AreEqual(2, areaOfBuilding);
        }
        [TestMethod]
        public void TestMethod2()
        {
            float areaOfBuilding = CalculateAreaOfBuilding(0, 0, 1, 0, 0, 1);
            Assert.AreEqual(0.5, areaOfBuilding);
        }
        float CalculateAreaOfBuilding(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            return (x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x2 * y1 - x1 * y3) / 2;
        }
    }
}
