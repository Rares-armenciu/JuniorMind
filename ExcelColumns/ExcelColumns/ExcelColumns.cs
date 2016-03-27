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
        public void TestForZZ()
        {
            Assert.AreEqual(702, GetNumberOfColumn("ZZ"));
        }
        [TestMethod]
        public void TestForThreeLetters()
        {
            Assert.AreEqual(703, GetNumberOfColumn("AAA"));
        }
        [TestMethod]
        public void MyTestMethod()
        {
            Assert.AreEqual(728, GetNumberOfColumn("AAZ"));
        }
        private int GetNumberOfColumn(string columnInLetters)
        {
            int finalResult = 1;
            for(int i=0; i<columnInLetters.Length; i++)
            {
                if (i != columnInLetters.Length - 1)
                {
                    finalResult *= (columnInLetters[i] - 'A' + 1) * 26;
                    finalResult++;
                }
                else
                {
                    finalResult += columnInLetters[i] - 'A';
                }
            }
            return finalResult;
        }
    }
}
