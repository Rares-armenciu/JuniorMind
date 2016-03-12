using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportRounds
{
    [TestClass]
    public class SportRepetitions
    {
        [TestMethod]
        public void TestMethod1()
        {
            int noOfRepetitions = CalculateTotalNoOfRepetitions(3);
            Assert.AreEqual(9, noOfRepetitions);
        }
        int CalculateTotalNoOfRepetitions(int rounds)
        {
            return (rounds-1)*(rounds)+rounds;
        }
    }
}
