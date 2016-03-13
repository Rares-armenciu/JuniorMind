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
            decimal areaOfBuilding = CalculateAreaOfBuilding(0, 0, 2, 0,1 , 2);
            Assert.AreEqual(2, areaOfBuilding);
        }
        decimal CalculateAreaOfBuilding(decimal x1, decimal y1, decimal x2, decimal y2, decimal x3, decimal y3)
        {
            return (x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x2 * y1 - x1 * y3) / 2;
        }
    }
}
