using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Debt
{
    [TestClass]
    public class Debt
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(41, CalculateTotalSumToPay(10, 31));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(102, CalculateTotalSumToPay(100, 1));
        }
        double CalculateTotalSumToPay(float rent, int lateDays)
        {
            return GetTotalDebt(rent, lateDays) + rent;
        }

        private double GetTotalDebt(float rent, int lateDays)
        {
            if (lateDays >= 1 && lateDays < 10)
                return rent * 0.02 * lateDays;
            if (lateDays > 10 && lateDays <= 30)
                return rent * 0.05 * lateDays;
            return rent * 0.1 * lateDays;
        }
    }
}
