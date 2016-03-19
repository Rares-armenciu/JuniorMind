using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LunchSchedule
{
    [TestClass]
    public class LunchSchedule
    {
        [TestMethod]
        public void TestIfWeMeetInTwelweDays()
        {
            Assert.AreEqual(12, CalculateMeetingTime(6, 4));
        }
        int CalculateMeetingTime(int mySchedule, int friendsSchedule)
        {
            return 0;
        }
    }
}
