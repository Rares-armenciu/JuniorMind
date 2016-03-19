    using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTable
{
    [TestClass]
    public class ChessTable
    {
        [TestMethod]
        public void TestForTwoOnTwoTable()
        {
            Assert.AreEqual(5, CalculateNumberOfSquares(2));
        }
        [TestMethod]
        public void TestForChessTable()
        {
            Assert.AreEqual(204, CalculateNumberOfSquares(8));
        }
        int CalculateNumberOfSquares(int dimension)
        {
            int squaresTotal = 0;
            for (int i = 1; i <= dimension; i++)
                squaresTotal += i * i;
            return squaresTotal;
        }
    }
}
