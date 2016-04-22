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
        public int GetRotations(int position)
        {
            return rotationsPerSecond[position].rotations;
        }
        public int getSecond(int position)
        {
            return rotationsPerSecond[position].second;
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
        [TestMethod]
        public void TestaForMediumSpeed()
        {
            Rotations[] firstCompetitor = new Rotations[] { new Rotations(1, 1), new Rotations(2, 3), new Rotations(3, 2) };
            Rotations[] secondCompetitor = new Rotations[] { new Rotations(1, 2), new Rotations(2, 4), new Rotations(3, 1) };
            Rotations[] thirdCompetitor = new Rotations[] { new Rotations(1, 3), new Rotations(2, 2), new Rotations(3, 1) };
            Bicyclist[] bicyclistList = new Bicyclist[] { new Bicyclist("Rares", firstCompetitor, 1), new Bicyclist("Cristi", secondCompetitor, 0.6),
                                          new Bicyclist("Sebi", thirdCompetitor, 0.8)};
            Assert.AreEqual("Rares", GetMediumSpeed(bicyclistList));
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
            int highestSpeed = bicyclistList[0].GetRotations(0);
            for(int i=0; i<bicyclistList.Length; i++)
                for(int j=0; j<bicyclistList[i].rotationsPerSecond.Length; j++)
                    if (bicyclistList[i].GetRotations(j) > highestSpeed)
                    {
                        bicyclist = i + 1;
                        highestSpeed = bicyclistList[i].GetRotations(j);
                        second = bicyclistList[i].getSecond(j);
                    }
            if(name)
                return bicyclist;
            return second;
        }
        string GetBicyclistName(Bicyclist[] bicyclistList)
        {
            return bicyclistList[GetFastestBicyclist(bicyclistList, true) - 1].name;
        }

        private string GetMediumSpeed(Bicyclist[] bicyclistList)
        {
            float meanValue = 0;
            float auiliary = 0;
            int position = 0;
            for (int i = 0; i < bicyclistList.Length; i++)
            {
                auiliary = 0;
                for (int j = 0; j < bicyclistList[i].rotationsPerSecond.Length; j++)
                    auiliary = (float)(auiliary + bicyclistList[i].GetRotations(j) * bicyclistList[i].wheelDiameter);
                if (auiliary / bicyclistList[i].rotationsPerSecond.Length > meanValue)
                {
                    meanValue = auiliary / bicyclistList[i].rotationsPerSecond.Length;
                    position = i;
                }
            }
            return bicyclistList[position].name;
                    
        }

    }
}
