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
        decimal CalculateKilogrammsOfHay(int noOfDays, int noOfGoats, decimal kgOfHay, int goats, int days)
        {
            decimal hayPerGoatPerDay = kgOfHay / (noOfDays * noOfGoats);
            return hayPerGoatPerDay*goats*days;
        }
    }
}
