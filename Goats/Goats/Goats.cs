using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goats
{
    [TestClass]
    public class Goats
    {
        [TestMethod]
        public void TestMethod1()
        {
            decimal amountOfHay = CalculateKilogrammsOfHay(1, 1, 3, 2, 1);
            Assert.AreEqual(6, amountOfHay);
        }
        [TestMethod]
        public void TestMethod2()
        {
            decimal amountOfHay = CalculateKilogrammsOfHay(2, 2, 5, 4, 4);
            Assert.AreEqual(20, amountOfHay);
        }
        decimal CalculateKilogrammsOfHay(int noOfDays, int noOfGoats, decimal kgOfHay, int days, int goats)
        {
            decimal hayPerGoatPerDay = kgOfHay / (noOfDays * noOfGoats);
            return hayPerGoatPerDay*goats*days;
        }
    }
}
