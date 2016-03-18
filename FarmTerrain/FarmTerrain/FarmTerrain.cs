using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FarmTerrain
{
    [TestClass]
    public class FarmTerrain
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(2, getTerrainSize(2, 8));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(770, getTerrainSize(230, 770000));
        }
        double getTerrainSize(int addedSize, int totalArea)
        {
            double sqrtDelta =Math.Sqrt( Math.Pow(addedSize, 2) + 4 * totalArea);
            if(getFirstValue(sqrtDelta, addedSize)>getSecondValue(sqrtDelta, addedSize))
                return getFirstValue(sqrtDelta, addedSize);
            return getSecondValue(sqrtDelta, addedSize);
        }
        double getFirstValue(double sqrtDelta, int addedSize)
        {
            return (sqrtDelta - addedSize) / 2;
        }
        double getSecondValue(double sqrtDelta, int addedSize)
        {
            return - (addedSize + sqrtDelta) / 2;
        }
    }
}
