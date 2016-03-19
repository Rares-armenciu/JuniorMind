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
            int[] priceForDay = { 5, 8, 6 };
            int[] priceForNight = { 7, 10, 8 };
            if (CheckIfItIsDay(travelHour))
                return priceForDay[PricePerKm(traveledDistance)] * traveledDistance;
            return priceForNight[PricePerKm(traveledDistance)] * traveledDistance;
        }
        private bool CheckIfItIsDay(int travelHour)
        {
            if (travelHour >= 8 && travelHour < 21)
                return true;
            return false;
        }
        private int PricePerKm(int traveledDistance)
        {
            if (traveledDistance <= 20)
                return 0;
            if (traveledDistance > 20 && traveledDistance <= 60)
                return 1;
            return 2;
        }



        

    }
}
