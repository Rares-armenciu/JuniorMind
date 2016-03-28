using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumnsInverted
{
    [TestClass]
    public class ExcelColumnsInverted
    {
        [TestMethod]
        public void TestForNumberOne()
        {
            Assert.AreEqual("A", GetColumnLetters(1));
        }
        [TestMethod]
        public void TestForTwoLetters()
        {
            Assert.AreEqual("AA", GetColumnLetters(27));
        }
        [TestMethod]
        public void TestForThreeLetters()
        {
            Assert.AreEqual("AAA", GetColumnLetters(703));
        }
        [TestMethod]
        public void SecondtestForTwoLetters()
        {
            Assert.AreEqual("ZZ", GetColumnLetters(702));
        }
        [TestMethod]
        public void SecondTestForThreeLetters()
        {
            Assert.AreEqual("ABZ", GetColumnLetters(754));
        }
        string GetColumnLetters(int columnNumber)
        {
            string columnLetters = string.Empty;
            while(columnNumber>0)
            {
                columnNumber--;
                columnLetters = columnLetters + GetLettersOfNumber(columnNumber%26);
                columnNumber /= 26;
            }
            return columnLetters;
        }
        char GetLettersOfNumber(int number)
        {
            return (char)(number + 'A');
        }
    }
}
