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
            Assert.AreEqual(50, CalculateTotalPrice(9, 10));
        }
        int CalculateTotalPrice(int hour, int distance)
        {
            if (hour > 7 && hour < 22)
            {
                if (distance > 0 && distance < 21)
                    return distance * 5;
                if (distance > 20 && distance < 61)
                    return distance * 8;
                if (distance > 60)
                    return distance * 6;
                else return 0;
            }
            if((hour>=0 && hour<8)||(hour>21&&hour<25))
            {
                if (distance > 0 && distance < 21)
                    return distance * 7;
                if (distance > 20 && distance < 61)
                    return distance * 10;
                if (distance > 60)
                    return distance * 8;
                else return 0;
            }
            else return 0;
        }
    }
}
