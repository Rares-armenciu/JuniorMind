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
            Priority[] prioritiesList = new Priority[] { Priority.Low, Priority.Medium, Priority.High}; 
            CollectionAssert.AreEqual(new int[] { 3, 2, 1 }, SetPrioritiesInOrder(prioritiesList));
        }
        [TestMethod]
        public void ComplexTest()
        {
            Priority[] prioritiesList = new Priority[] { Priority.High, Priority.Low, Priority.Low, Priority.Medium, Priority.High, Priority.Low };
            CollectionAssert.AreEqual(new int[] { 1, 5, 4, 2, 3, 6 }, SetPrioritiesInOrder(prioritiesList));
        }
        int[] SetPrioritiesInOrder(Priority[] priorityList)
        {
            Client[] clientList = new Client[priorityList.Length];
            for(int i=0; i<priorityList.Length; i++)
            {
                clientList[i] = new Client(priorityList[i]);
            }
            Service s = new Service(clientList);
            int[] clientsOrder = new int[priorityList.Length];
            for (int i = 0; i < clientsOrder.Length; i++)
                clientsOrder[i] = s.GetNextCase(i);
            return clientsOrder;
        }
    }
}
