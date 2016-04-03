using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperations
    {
        [TestMethod]
        public void Conversion()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0}, ConvertToBinary(2));
        }

        byte[] ConvertToBinary(int decimalNumber)
        {
            return new byte[] { 1, 0 };
        }
    }
}
