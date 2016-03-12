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
        int CalculateNeededNumberOfCubicalStone(int StreetLength, int StreetWidth, int CubicalStone)
        {
            int Length = StreetLength / CubicalStone;
            int Width = StreetWidth / CubicalStone;
            return Length*Width;
        }
    }
}
