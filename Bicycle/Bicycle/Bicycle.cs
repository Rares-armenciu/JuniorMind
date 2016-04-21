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
    public struct Bicyclist
    {
        public string name;
        public Rotations[] rotationsPerSecond;
        public double wheelDiameter;
        public Bicyclist(string name, Rotations[] rotations, double diameter)
        {
            this.name = name;
            rotationsPerSecond = rotations;
            wheelDiameter = diameter;
        }
    }
    [TestClass]
    public class Bicycle
    {
        [TestMethod]
        public void TestForFullDistance()
        {
            Rotations[] firstCompetitor = new Rotations[] { new Rotations(1, 1), new Rotations(2, 3), new Rotations(3, 2) };
            Rotations[] secondCompetitor = new Rotations[] { new Rotations(1, 2), new Rotations(2, 4), new Rotations(3, 1) };
            Rotations[] thirdCompetitor = new Rotations[] { new Rotations(1, 3), new Rotations(2, 2), new Rotations(3, 1) };
            Assert.AreEqual(6, GetFullDistance(new Bicyclist("Rares", firstCompetitor, 1)));
            Assert.AreEqual(4.2, Math.Round(GetFullDistance(new Bicyclist("Cristi", secondCompetitor, 0.6)), 1));
            Assert.AreEqual(4.8, Math.Round(GetFullDistance(new Bicyclist("Sebi", thirdCompetitor, 0.8)), 1));
        }
        [TestMethod]
        public void TestForFastestBicyclist()
        {
            Rotations[] firstCompetitor = new Rotations[] { new Rotations(1, 1), new Rotations(2, 3), new Rotations(3, 2) };
            Rotations[] secondCompetitor = new Rotations[] { new Rotations(1, 2), new Rotations(2, 4), new Rotations(3, 1) };
            Rotations[] thirdCompetitor = new Rotations[] { new Rotations(1, 3), new Rotations(2, 2), new Rotations(3, 1) };
            Bicyclist[] bicyclistList = new Bicyclist[] { new Bicyclist("Rares", firstCompetitor, 1), new Bicyclist("Cristi", secondCompetitor, 0.6),
                                          new Bicyclist("Sebi", thirdCompetitor, 0.8)};
            Assert.AreEqual("Cristi", GetBicyclistName(bicyclistList));
            Assert.AreEqual(2, GetFastestBicyclist(bicyclistList, false));
        }

        double GetFullDistance(Bicyclist bicyclist)
        {
            double distance = 0;
            for (int i = 0; i < bicyclist.rotationsPerSecond.Length; i++)
                distance += bicyclist.rotationsPerSecond[i].rotations * bicyclist.wheelDiameter;
            return distance;
        }
        int GetFastestBicyclist(Bicyclist[] bicyclistList, bool name)
        {
            int bicyclist = 0, second = 0;
            int highestSpeed = bicyclistList[0].rotationsPerSecond[0].rotations;
            for(int i=0; i<bicyclistList.Length; i++)
                for(int j=0; j<bicyclistList[i].rotationsPerSecond.Length; j++)
                    if (bicyclistList[i].rotationsPerSecond[j].rotations > highestSpeed)
                    {
                        bicyclist = i + 1;
                        highestSpeed = bicyclistList[i].rotationsPerSecond[j].rotations;
                        second = bicyclistList[i].rotationsPerSecond[j].second;
                    }
            if(name)
                return bicyclist;
            return second;
        }

        string GetBicyclistName(Bicyclist[] bicyclistList)
        {
            return bicyclistList[GetFastestBicyclist(bicyclistList, true) - 1].name;
        }
    }
}
