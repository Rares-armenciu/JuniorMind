using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExcelColumns
{
    [TestClass]
    public class ExcelColumns
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, GetNumberOfColumn("A"));
        }

        private int GetNumberOfColumn(string columnInLetters)
        {
            int finalResult = 0;
            for(int i=0; i<columnInLetters.Length; i++)
            {
                finalResult *= 10;
                finalResult += columnInLetters[i] - 'A';
            }
            return finalResult+1;
        }
    }
}
