using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlyingBird
{
    [TestClass]
    public class FlyingBird
    {
        [TestMethod]
        public void TestMethod1()
        {
            float distance = CalculateFlyDistance(20, 80);
            Assert.AreEqual(40, distance);
        }
        float CalculateFlyDistance(float trainSpeed, float trainDistance)
        {
            float birdTravelTime = trainDistance / (trainSpeed * 2) - ((trainDistance / 4) / trainSpeed);
            return trainSpeed*2*birdTravelTime;
        }
    }
}
