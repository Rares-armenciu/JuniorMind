using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotteryDraw
{
    [TestClass]
    public class LotteryDraw
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] expectedNumbers = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNumbers, SortArrayOfNumbers(new int[] { 3, 2, 1 }));
        }

        private int[] SortArrayOfNumbers(int[] numberList)
        {
            BubbleSort sort = new BubbleSort(numberList);
            return sort.SortNumbers();
        }
    }
}
