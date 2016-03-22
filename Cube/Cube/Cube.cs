using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cube
{
    [TestClass]
    public class Cube
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(192, GetCubeNumber(1));
        }
        int GetCubeNumber(int wantedNumber)
        {
            return 0;
        }
    }
}
