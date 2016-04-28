using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LotteryDraw
{
    [TestClass]
    public class LotteryDraw
    {
        [TestMethod]
        public void SimpleTest()
        {
            int[] expectedNumbers = new int[] { 1, 2, 3 };
            CollectionAssert.AreEqual(expectedNumbers, SortArrayOfNumbers(new int[] { 3, 2, 1 }));
        }
        [TestMethod]
        public void MoreComplexTest()
        {
            int[] expectedNumbers = new int[] { 5, 7, 9, 16, 20, 32, 55, 62, 76, 91, 100 };
            CollectionAssert.AreEqual(expectedNumbers, SortArrayOfNumbers(new int[] { 100, 20, 5, 32, 55, 9, 62, 91, 76, 7, 16 }));
        }

        private int[] SortArrayOfNumbers(int[] numberList)
        {
            BubbleSort sort = new BubbleSort(numberList);
            return sort.SortNumbers();
        }
    }
}
