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
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1 }, LogicOperations(ConvertToBinary(1), ConvertToBinary(7), "AND"));
        }
        [TestMethod]
        public void TestForOROperand()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, LogicOperations(ConvertToBinary(1), ConvertToBinary(7), "OR"));
        }
        [TestMethod]
        public void TestForXOROperand()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, LogicOperations(ConvertToBinary(1), ConvertToBinary(7), "XOR"));
        }
        [TestMethod]
        public void TestForNotOperand()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0 }, NOTOperation(ConvertToBinary(7)));
        }
        [TestMethod]
        public void TestForRightHandShift()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 1 }, Shifting(ConvertToBinary(7), "Right"));
        }
        [TestMethod]
        public void TestForLeftHandShift()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0 }, Shifting(ConvertToBinary(7), "Left"));
        }
        [TestMethod]
        public void OneIsLessThatSeven()
        {
            Assert.AreEqual(true, LessThan(ConvertToBinary(1), ConvertToBinary(7)));
        }
        [TestMethod]
        public void SevenIsNotLessThanOne()
        {
            Assert.AreEqual(false, LessThan(ConvertToBinary(7), ConvertToBinary(1)));
        }
        [TestMethod]
        public void SevenIsGreaterThanOne()
        {
            Assert.AreEqual(true, LessThan(ConvertToBinary(1), ConvertToBinary(7)));
        }
        [TestMethod]
        public void SevenIsEqualToSeven()
        {
            Assert.AreEqual(false, (LessThan(ConvertToBinary(7), ConvertToBinary(7)) | LessThan(ConvertToBinary(7), ConvertToBinary(7))));
        }
        [TestMethod]
        public void OneIsNotEqualToSeven()
        {
            Assert.AreEqual(true, (LessThan(ConvertToBinary(1), ConvertToBinary(7)) | LessThan(ConvertToBinary(7), ConvertToBinary(1))));
        }
        [TestMethod]
        public void ThreePlusFour()
        {
            CollectionAssert.AreEqual(ConvertToBinary(3 + 4), Addition(ConvertToBinary(3), ConvertToBinary(4)));
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
        byte[] LogicOperations(byte[] firstNumber, byte[] secondNumber, string operation)
        {
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            for (int i = 0; i<result.Length; i++)
            {
                byte firstNumberByte = AddZeroes(firstNumber, i);
                byte secondNumberByte = AddZeroes(secondNumber, i);
                result[i] = LogicOperations2(firstNumberByte, secondNumberByte, operation);
    
            }
            return ReverseBits(result);
        }

        byte Xor(byte firstNumberByte, byte secondNumberByte)
        {
            if (firstNumberByte != secondNumberByte)
                return 1;
            return 0;
        }

        byte Or(byte firstNumberByte, byte secondNumberByte)
        {
            if (firstNumberByte == 1 || secondNumberByte == 1)
                return 1;
            return 0;
        }

        byte And(byte firstNumberByte, byte secondNumberByte)
        {
            if (firstNumberByte == secondNumberByte && firstNumberByte == 1)
                return 1;
            return 0;
        }
        byte LogicOperations2(byte firstNumber, byte secondNumber, string operation)
        {
            switch (operation)
            {
                case "AND":
                    return And(firstNumber, secondNumber);
                case "OR":
                    return Or(firstNumber, secondNumber);
                case "XOR":
                    return Xor(firstNumber, secondNumber);
            }
            return 0;
        }
        byte AddZeroes(byte[] number, int position)
        {
            if (position > (number.Length - 1))
                return 0;
            return number[position];
        }
        byte[] NOTOperation(byte[] numberToNegate)
        {
            byte[] negatedNumber = new byte[numberToNegate.Length];
            for(int i=0; i<numberToNegate.Length; i++)
            {
                if (numberToNegate[i] == 1)
                    negatedNumber[i] = 0;
                else
                    negatedNumber[i] = 1;
            }
            return negatedNumber;
        }
        byte[] Shifting(byte[] numberToShift, string shiftDirection)
        {
            switch (shiftDirection)
            {
                case "Right":
                    for (int i = numberToShift.Length - 1; i > 0; i--)
                        numberToShift[i] = numberToShift[i - 1];
                    numberToShift[0] = 0;
                    break;
                case "Left":
                    for (int i = 0; i < numberToShift.Length - 1; i++)
                        numberToShift[i] = numberToShift[i + 1];
                    numberToShift[numberToShift.Length - 1] = 0;
                    break;
            }
            return numberToShift;
        }
        bool LessThan(byte[] firstNumber, byte[] secondNumber)
        {
            for (int i = 0; i < Math.Max(firstNumber.Length, secondNumber.Length); i++)
                if (AddZeroes(firstNumber, i) != AddZeroes(secondNumber, i))
                    return (AddZeroes(firstNumber, i) < AddZeroes(secondNumber, i));
            return false;
        }
        byte[] Addition(byte[] firstNumber, byte[] secondNumber)
        {
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            int reminder = 0;
            for(int i=result.Length-1; i>=0; i--)
            {
                int sum = AddZeroes(firstNumber, i) + AddZeroes(secondNumber, i) + reminder;
                result[i] = (byte)(sum % 2);
                reminder = sum / 2;
            }
            if(reminder!=0)
            {
                result = ReverseBits(result);
                Array.Resize(ref result, 1);
                result[result.Length - 1] = (byte)reminder;
                result = ReverseBits(result);
            }
            return result;
        }
    }
}
