using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StreetPavement
{
    [TestClass]
    public class StreetPavement
    {
        [TestMethod]
        public void TestMethod1()
        {
            int Result = CalculateNeededNumberOfCubicalStone(4, 4, 4);
            Assert.AreEqual(1, Result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int Result = CalculateNeededNumberOfCubicalStone(6, 6, 4);
            Assert.AreEqual(4, Result);
        }
        int CalculateNeededNumberOfCubicalStone(int StreetLength, int StreetWidth, int CubicalStone)
        {
            int Length = StreetLength / CubicalStone;
            int Width = StreetWidth / CubicalStone;
            if (StreetLength % CubicalStone > 0)
                Length += 1;
            if (StreetWidth % CubicalStone > 0)
                Width += 1;
            return Length *Width;
        }
    }
}
