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
        [TestMethod]
        public void ConversionForHigherNumber()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1 }, ConvertToBinary(15));
        }
        byte[] ConvertToBinary(int decimalNumber)
        {
            byte[] binaryNumber = new byte[0];
            int i = 0;
            while (decimalNumber > 0)
            {
                Array.Resize(ref binaryNumber, i + 1);
                binaryNumber[i] = (byte)(decimalNumber % 2);
                decimalNumber /= 2;
                i++;
            }
            return ReverseBits(binaryNumber);
        }
        byte[] ReverseBits(byte[] numberToReverse)
        {
            byte[] reversedNumber = new byte[numberToReverse.Length];
            for(int i=0; i<reversedNumber.Length; i++)
            {
                reversedNumber[i] = numberToReverse[numberToReverse.Length - i - 1];
            }
            return reversedNumber;
        }
    }
}
