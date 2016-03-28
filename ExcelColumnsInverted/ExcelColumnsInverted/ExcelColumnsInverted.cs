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
        string GetColumnLetters(int columnNumber)
        {
            string columnLetters = string.Empty;
            if (columnNumber < 27)
                columnLetters = columnLetters + (char)(columnNumber + 64);
            return columnLetters;
        }
    }
}
