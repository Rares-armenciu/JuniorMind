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
        float CalculateTotalSumToPay(double rent, int lateDays)
        {
            if (lateDays > 0 && lateDays < 11)
                rent += rent * 0.02 * lateDays;
            else if (lateDays > 10 && lateDays < 31)
                rent += rent * 0.05 * lateDays;
            else if (lateDays > 30)
                rent += rent * 0.1 * lateDays;
            return (float) rent;
        }
    }
}
