using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaxiCharge
{
    [TestClass]
    public class TaxiCharge
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(10, CalculateTotalPrice(2, 10));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(300, CalculateTotalPrice(30, 24));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(800, CalculateTotalPrice(100, 5));
        }
        int CalculateTotalPrice(int traveledDistance, int travelHour)
        {
            if(CheckIfItIsDay(travelHour)==true)
                return PriceForDayTrip(traveledDistance);
            if (CheckIfItIsNight(travelHour) == true)
                return PriceForNightTrip(traveledDistance);
            return 0;
        }
        private bool CheckIfItIsDay(int travelHour)
        {
            if (travelHour >= 8 && travelHour < 21)
                return true;
            return false;
        }
        private bool CheckIfItIsNight(int travelHour)
        {
            if (travelHour >= 0 && travelHour < 8 || travelHour > 21 && travelHour <= 24)
                return true;
            return false;
        }
        private int PriceForDayTrip(int traveledDistance)
        {
            if (traveledDistance <= 20)
                return traveledDistance * 5;
            if (traveledDistance > 20 && traveledDistance <= 60)
                return traveledDistance * 8;
            return traveledDistance * 6;
        }
        private int PriceForNightTrip(int traveledDistance)
        {
            if (traveledDistance <= 20)
                return traveledDistance * 7;
            if (traveledDistance > 20 && traveledDistance <= 60)
                return traveledDistance * 10;
            return traveledDistance * 8;
        }



        

    }
}
