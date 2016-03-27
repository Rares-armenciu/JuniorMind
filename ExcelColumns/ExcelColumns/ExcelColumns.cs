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
            return 0;
        }
    }
}
