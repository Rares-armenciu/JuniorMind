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
            Assert.AreEqual("III", ConvertNumberToRoman(3));
        }
        string ConvertNumberToRoman(int number)
        {
            return string.Empty;
        }
    }
}
