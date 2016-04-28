using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceCenter
{
    [TestClass]
    public class ServiceCenter
    {
        [TestMethod]
        public void TestMethod1()
        {
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, SetPrioritiesInOrder(new string[] { "Low", "Medium", "High" }));
        }

        int[] SetPrioritiesInOrder(string[] v)
        {
            RepairOrder repair = new RepairOrder(v);
            return repair.SortPriorities();
        }
    }
}
