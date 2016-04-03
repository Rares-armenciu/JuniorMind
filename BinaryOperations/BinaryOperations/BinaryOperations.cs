using System;
using System.Collections;
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
        [TestMethod]
        public void TestForANDOperand()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1 }, ANDOperation(ConvertToBinary(1), ConvertToBinary(7)));
        }
        [TestMethod]
        public void TestForOROperand()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, OROperation(ConvertToBinary(1), ConvertToBinary(7)));
        }
        [TestMethod]
        public void TestForXOROperand()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, XOROperation(ConvertToBinary(1), ConvertToBinary(7)));
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
        byte[] ANDOperation(byte[] firstNumber, byte[] secondNumber)
        {
            return LogicOperations(firstNumber, secondNumber, "AND");
        }
        byte[] OROperation(byte[] firstNumber, byte[] secondNumber)
        {
            return LogicOperations(firstNumber, secondNumber, "OR");
        }
        byte[] XOROperation(byte[] firstNumber, byte[] secondNumber)
        {
            return LogicOperations(firstNumber, secondNumber, "XOR");
        }

        private byte[] LogicOperations(byte[] firstNumber, byte[] secondNumber, string operation)
        {
            firstNumber = ReverseBits(firstNumber);
            secondNumber = ReverseBits(secondNumber);
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            for (int i = 0; i<result.Length; i++)
            {
                switch (operation)
                {
                    case "AND":
                        if (AddZeroes(firstNumber, i) == AddZeroes(secondNumber, i) && AddZeroes(firstNumber, i) == 1)
                            result[i] = 1;
                        else
                            result[i] = 0;
                        break;
                    case "OR":
                        if (AddZeroes(firstNumber, i) == 1 || AddZeroes(secondNumber, i) == 1)
                            result[i] = 1;
                        else
                            result[i] = 0;
                        break;
                    case "XOR":
                        if (AddZeroes(firstNumber, i) != AddZeroes(secondNumber, i))
                            result[i] = 1;
                        else
                            result[i] = 0;
                        break;
                }
            }
            return ReverseBits(result);
        }
        byte AddZeroes(byte[] number, int position)
        {
            if (position > (number.Length - 1))
                return 0;
            return number[position];
        }
    }
}
