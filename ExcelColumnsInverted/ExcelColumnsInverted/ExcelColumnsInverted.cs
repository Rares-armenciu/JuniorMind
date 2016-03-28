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
            if (columnNumber > 702)
            {
                columnLetters = columnLetters + GetLettersOfNumber(columnNumber / 702);
                columnNumber %= 676;
            }
            if (columnNumber > 26 && columnNumber <= 702)
            {
                if (columnNumber % 26 == 0)
                {
                    columnLetters = columnLetters + GetLettersOfNumber((columnNumber - 1) / 26);
                    columnNumber = 26;
                }
                else
                {
                    columnLetters = columnLetters + GetLettersOfNumber((columnNumber) / 26);
                    columnNumber %= 26;
                }
            }
            columnLetters = columnLetters + GetLettersOfNumber(columnNumber);
            return columnLetters;
        }
        char GetLettersOfNumber(int number)
        {
            return (char)(number + 64);
        }
    }
}
