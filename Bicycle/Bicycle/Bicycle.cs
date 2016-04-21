using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bicycle
{
    public struct Rotations
    {
        public int second, rotations;
        public Rotations(int x, int y)
        {
            second = x;
            rotations = y;
        }
    }
    [TestClass]
    public class Bicycle
    {
        [TestMethod]
        public void TestMethod1()
        {
            Rotations[] firstCompetitor = new Rotations[] { new Rotations(1, 1), new Rotations(2, 3), new Rotations(3, 2) };
            Rotations[] secondCompetitor = new Rotations[] { new Rotations(1, 2), new Rotations(2, 4), new Rotations(3, 1) };
            Rotations[] thirdCompetitor = new Rotations[] { new Rotations(1, 3), new Rotations(2, 2), new Rotations(3, 1) };
            Assert.AreEqual(6, GetFullDistance(firstCompetitor, 1));
            Assert.AreEqual(4.2, Math.Round(GetFullDistance(secondCompetitor, 0.6), 1));
            Assert.AreEqual(4.8, Math.Round(GetFullDistance(thirdCompetitor, 0.8), 1));
        }

        double GetFullDistance(Rotations[] competitor, double wheelDiameter)
        {
            double distance = 0;
            for (int i = 0; i < competitor.Length; i++)
                distance += competitor[i].rotations * wheelDiameter;
            return distance;
        }
    }
}
