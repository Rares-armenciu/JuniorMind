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
        string GetColumnLetters(int columnNumber)
        {
            string columnLetters = string.Empty;
            if (columnNumber < 27)
                columnLetters = columnLetters + (char)(columnNumber + 64);
            if(columnNumber > 26 && columnNumber <= 702)
            {
                columnLetters = columnLetters + (char)(columnNumber / 26 + 64);
                columnLetters = columnLetters + (char)(columnNumber % 26 + 64);
            }
            return columnLetters;
        }
    }
}
