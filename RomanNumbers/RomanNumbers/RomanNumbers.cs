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
            Assert.AreEqual("XIV", ConvertNumberToRoman(14));
        }
        string ConvertNumberToRoman(int number)
        {
            string romanNumber = null;
            int[] roman = { 1, 5, 10, 50, 100 };
            string roman2 = "IVXLC";
            for(int i=4; i>-1; i--)
            {
                if(number/roman[i]!=0)
                {
                    if(number>=90)
                    {
                        romanNumber = "XC";
                        number -= 90;
                        i = 2;
                    }
                    if(number/roman[i]==4)
                    {
                        romanNumber += roman2[i];
                        romanNumber += roman2[i + 1];
                    }
                    else
                    {
                        romanNumber += roman2[i];
                        number -= roman[i];
                    }
                }
            }
            return romanNumber;
        }
    }
}
