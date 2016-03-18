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
        string ConvertNumberToRoman(int number)
        {
            string romanNumber = null;
            int[] roman = { 1, 4, 5, 9, 10, 40, 50, 90, 100 };
            string[] roman2 = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C" };
            for(int i=8; i>-1; i--)
            {
                while(number/roman[i]!=0)
                {
                    romanNumber += roman2[i];
                    number -= roman[i];
                }
            }
            return romanNumber;
        }
    }
}
