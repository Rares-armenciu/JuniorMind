    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTable
{
    [TestClass]
    public class ChessTable
    {
        [TestMethod]
        public void TestForFourOnFOurTable()
        {
            Assert.AreEqual(5, CalculateNumberOfSquares(4));
        }
        int CalculateNumberOfSquares(int dimension)
        {
            return 0;
        }
    }
}
