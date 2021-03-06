﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParquetPlates
{
    [TestClass]
    public class ParguetPlates
    {
        [TestMethod]
        public void TestMethod1()
        {
            double numberOfPlates = GetNumberOfNeededPlates(3.4, 2, 1, 2);
            Assert.AreEqual(4, numberOfPlates);
        }
        [TestMethod]
        public void TestMethod2()
        {
            double numberOfPlates = GetNumberOfNeededPlates(51, 10, 4, 3);
            Assert.AreEqual(50, numberOfPlates);
        }
        double GetNumberOfNeededPlates(double roomLength, double roomWidth, double plateLength, double plateWidth)
        {
            return (roomLength * roomWidth) / (plateLength * plateWidth * 0.85);
        }
    }
}
