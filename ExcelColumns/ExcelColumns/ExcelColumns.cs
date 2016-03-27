using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumns
{
    [TestClass]
    public class ExcelColumns
    {
        [TestMethod]
        public void TestForA()
        {
            Assert.AreEqual(1, GetNumberOfColumn("A"));
        }
        [TestMethod]
        public void TestForAA()
        {
            Assert.AreEqual(27, GetNumberOfColumn("AA"));
        }
        [TestMethod]
        public void TestForBA()
        {
            Assert.AreEqual(53, GetNumberOfColumn("BA"));
        }
        [TestMethod]
        public void TestForThreeLetters()
        {
            Assert.AreEqual(703, GetNumberOfColumn("AAA"));
        }
        private int GetNumberOfColumn(string columnInLetters)
        {
            int finalResult = 0;
            int i = 0;
            while(i<columnInLetters.Length)
            {
                if (i!=columnInLetters.Length-1)
                {
                    finalResult = (columnInLetters[i] - 'A' + 1) * 26;
                    i++;
                }
                finalResult += columnInLetters[i] - 'A';
                i++;
            }
            return finalResult+1;
        }
    }
}
