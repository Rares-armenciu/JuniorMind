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
        [TestMethod]
        public void TestForExceptionlCase()
        {
            Assert.AreEqual(4, CalculateMeetingTime(4, 4));
        }
        int CalculateMeetingTime(int mySchedule, int friendsSchedule)
        {
            int productOfNumbers = mySchedule * friendsSchedule;
            if (mySchedule == friendsSchedule)
                return mySchedule;
            if (productOfNumbers % CalculateDifference(mySchedule, friendsSchedule) == 0)
                return productOfNumbers / CalculateDifference(mySchedule, friendsSchedule);
            return productOfNumbers;
        }

        private int CalculateDifference(int mySchedule, int friendsSchedule)
        {
            if (mySchedule > friendsSchedule)
                return mySchedule - friendsSchedule;
            return friendsSchedule - mySchedule;
        }
    }
}
