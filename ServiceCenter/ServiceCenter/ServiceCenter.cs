using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceCenter
{
    [TestClass]
    public class ServiceCenter
    {
        [TestMethod]
        public void SimpleTest()
        {
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, SetPrioritiesInOrder(new string[] { "Low", "Medium", "High" }));
        }
        [TestMethod]
        public void ComplexTest()
        {
            CollectionAssert.AreEqual(new int[] { 4, 6, 2, 7, 1, 3, 5}, SetPrioritiesInOrder(new string[] { "Low", "Medium", "Low", "High", "Low", "High", "Medium" }));
        }
        int[] SetPrioritiesInOrder(string[] v)
        {
            RepairOrder repair = new RepairOrder(v);
            return repair.SortPriorities();
        }
    }
}
