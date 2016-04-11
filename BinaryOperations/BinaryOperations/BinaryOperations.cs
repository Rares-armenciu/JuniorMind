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
            CollectionAssert.AreEqual(ConvertToBinary(3 + 4), Addition(ConvertToBinary(3), ConvertToBinary(4), 2));
        }
        [TestMethod]
        public void FifteenPlusTen()
        {
            CollectionAssert.AreEqual(ConvertToBinary(15+10), Addition(ConvertToBinary(15), ConvertToBinary(10), 2));
        }
        [TestMethod]
        public void EightMinusSeven()
        {
            CollectionAssert.AreEqual(ConvertToBinary(8 - 7), Substraction(ConvertToBinary(8), ConvertToBinary(7), 2));
        }
        [TestMethod]
        public void SeventeenMinusTen()
        {
            CollectionAssert.AreEqual(ConvertToBinary(17 - 10), Substraction(ConvertToBinary(17), ConvertToBinary(10), 2));
        }
        [TestMethod]
        public void TwentyMinusTwo()
        {
            CollectionAssert.AreEqual(ConvertToBinary(20-2), Substraction(ConvertToBinary(20), ConvertToBinary(2), 2));
        }
        [TestMethod]
        public void TenTimesFive()
        {
            CollectionAssert.AreEqual(ConvertToBinary(10*5), Multiplication(ConvertToBinary(10), ConvertToBinary(5), 2));
        }
        [TestMethod]
        public void NineOverThree()
        {
            CollectionAssert.AreEqual(ConvertToBinary(9/3), Division(ConvertToBinary(9), ConvertToBinary(3), 2));
        }
        [TestMethod]
        public void TwentyOverTwo()
        {
            CollectionAssert.AreEqual(ConvertToBinary(20 / 2), Division(ConvertToBinary(20), ConvertToBinary(2), 2));
        }

        [TestMethod]
        public void ConversionIntoBaseSixteen()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0 }, ConvertToAnyBase(16, 16));
        }
        [TestMethod]
        public void ConversionToHighestBase()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 255 }, ConvertToAnyBase(511, 256));
        }
        [TestMethod]
        public void TwelveIsLessThanFifteenInBaseFour()
        {
            Assert.AreEqual(true, LessThan(ConvertToAnyBase(12, 4), ConvertToAnyBase(15, 4)));
        }
        [TestMethod]
        public void TwentyIsNotLessThanTenInBaseEight()
        {
            Assert.AreEqual(false, LessThan(ConvertToAnyBase(20, 8), ConvertToAnyBase(10, 8)));
        }
        [TestMethod]
        public void TwentyPlusFourteenInBaseFive()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(20 + 14, 5), Addition(ConvertToAnyBase(20, 5), ConvertToAnyBase(14, 5), 5));
        }
        [TestMethod]
        public void AdditionInHigherBase()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(1256 + 475, 256), Addition(ConvertToAnyBase(1256, 256), ConvertToAnyBase(475, 256), 256));
        }
        [TestMethod]
        public void FourtyMinusFourteenInBaseEight()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(40 - 14, 8), Substraction(ConvertToAnyBase(40, 8), ConvertToAnyBase(14, 8), 8));
        }
        [TestMethod]
        public void EighteenTimesTenInBaseTwelve()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(18 * 10, 12), Multiplication(ConvertToAnyBase(18, 12), ConvertToAnyBase(10, 12), 12));
        }
        [TestMethod]
        public void MultiplicationInHighBase()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(224 * 132, 200), Multiplication(ConvertToAnyBase(224, 200), ConvertToAnyBase(132, 200), 200));
        }
        [TestMethod]
        public void DivisionInLowerBase()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(72 / 8, 9), Division(ConvertToAnyBase(72, 9), ConvertToAnyBase(8, 9), 9));
        }
        [TestMethod]
        public void DivisionInHigherBase()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(2048 / 128, 200), Division(ConvertToAnyBase(2048, 200), ConvertToAnyBase(128, 200), 200));
        }
        [TestMethod]
        public void SixFactorial()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(720, 256), Factorial(6, 256));
        }
        [TestMethod]
        public void FourtyNineFactorial()
        {
            CollectionAssert.AreEqual(ConvertToAnyBase(3628800, 256), Factorial(10, 256));
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
        byte[] ConvertToAnyBase(double numberToConvert, int baseToConvert)
        {
            byte[] convertedNumber = new byte[0];
            int i = 0;
            while (numberToConvert > 0)
            {
                Array.Resize(ref convertedNumber, i + 1);
                convertedNumber[i] = (byte)(numberToConvert % baseToConvert);
                numberToConvert = (int)numberToConvert / baseToConvert;
                i++;
            }
            return ReverseBits(convertedNumber);
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
                result[i] = LogicOperations(firstNumberByte, secondNumberByte, operation);
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
        byte LogicOperations(byte firstNumber, byte secondNumber, string operation)
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
            number = ReverseBits(number);
            if (position >= (number.Length))
                return (byte)0;
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
            if (firstNumber.Length > secondNumber.Length)
                return false;
            if (firstNumber.Length < secondNumber.Length)
                return true;
            for (int i = 0; i < Math.Max(firstNumber.Length, secondNumber.Length); i++)
                if (AddZeroes(firstNumber, i) != AddZeroes(secondNumber, i))
                    return (AddZeroes(firstNumber, i) < AddZeroes(secondNumber, i));
            return false;
        }
        bool NotEqual(byte[] firstNumber, byte[] secondNumber)
        {
            if (LessThan(firstNumber, secondNumber) == true || LessThan(secondNumber, firstNumber) == true)
                return true;
            return false;
        }
        byte[] Addition(byte[] firstNumber, byte[] secondNumber, int conversionBase)
        {
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            int reminder = 0;
            for(int i=0; i<result.Length; i++)
            {
                int sum = AddZeroes(firstNumber, i) + AddZeroes(secondNumber, i) + reminder;
                result[i] = (byte)(sum % conversionBase);
                reminder = sum / conversionBase;
            }
            if(reminder!=0)
            {
                Array.Resize(ref result, result.Length+1);
                result[result.Length - 1] = (byte)reminder;
            }
            return ReverseBits(result);
        }
        byte[] Substraction(byte[] firstNumber, byte[] secondNumber, int conversionBase)
        {
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            int reminder = 0;
            int counter = 0;
            for(int i=0; i<result.Length; i++)
            {
                int difference = AddZeroes(firstNumber, i) - AddZeroes(secondNumber, i) - reminder;
                if (difference < 0)
                {
                    difference += conversionBase;
                    reminder = 1;
                }
                else reminder = 0;
                result[i] = (byte)difference;
                if (result[i] == 0)
                    counter++;
                else counter = 0;
            }
            if (counter != 0)
            {
                byte[] newResult = new byte[result.Length - counter];
                for (int i = 0; i < newResult.Length; i++)
                    newResult[i] = result[i];
                return ReverseBits(newResult);
            }
            return ReverseBits(result);
        }
        byte[] Multiplication(byte[] firstNumber, byte[] secondNumber, int conversionBase)
        {
            byte[] result = new byte[Math.Max(firstNumber.Length, secondNumber.Length)];
            while (NotEqual(secondNumber, ConvertToBinary(0)))
            {
                result = Addition(result, firstNumber, conversionBase);
                secondNumber = Substraction(secondNumber, ConvertToBinary(1), conversionBase);
            }
            return result;
        }
        byte[] Division(byte[] firstNumber, byte[] secondNumber, int conversionBase)
        {
            int divisionCounter = 0;
            while (NotEqual(firstNumber, ConvertToBinary(0)))
            {
                firstNumber = Substraction(firstNumber, secondNumber, conversionBase);
                divisionCounter++;
            }
            return ConvertToAnyBase(divisionCounter, conversionBase);
        }
        byte[] Factorial(int numberToCalulate, int conversionBase)
        {
            byte[] finalNumber = ConvertToAnyBase(1, conversionBase);
            for(int i=2; i<=numberToCalulate; i++)
            {
                finalNumber = Multiplication(finalNumber, ConvertToAnyBase(i, conversionBase), conversionBase);
            }
            return finalNumber;
        }
    }
}
