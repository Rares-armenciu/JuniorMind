using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumbers
{
    [TestClass]
    public class RomanNumbers
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("LI", ConvertNumberToRoman(51));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("XIII", ConvertNumberToRoman(13));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("XCIX", ConvertNumberToRoman(99));
        }
        string ConvertNumberToRoman(int numberToConvert)
        {
            string convertedNumber = null;
            int[] arabicNumbers = { 1, 4, 5, 9, 10, 40, 50, 90, 100 };
            string[] romanNumbers = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C" };
            for(int i=arabicNumbers.Length-1; i>-1; i--)
            {
                while(numberToConvert >= arabicNumbers[i])
                {
                    convertedNumber += romanNumbers[i];
                    numberToConvert -= arabicNumbers[i];
                }
            }
            return convertedNumber;
        }
    }
}
