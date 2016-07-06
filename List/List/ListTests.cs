using System;
using Xunit;

namespace List
{
    public class ListTests
    {
        [Fact]
        public void ListIsEmpty()
        {
            var list = new List<int>();
            Assert.Equal(0, list.Count);
        }
        [Fact]
        public void AddElementsToList()
        {
            var list = new List<int>() { 1, 2 };
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ClearList()
        {
            var list = new List<int>() { 1, 2 };
            list.Clear();
            Assert.Equal(0, list.Count);
        }
        [Fact]
        public void CheckIfListContainsElement()
        {
            var list = new List<int>() { 1, 2, 3 };
            Assert.True(list.Contains(2));
            Assert.False(list.Contains(4));
        }
        [Fact]
        public void RemoveItemFromList()
        {
            var list = new List<int>() { 1, 2, 3 };
            Assert.True(list.Remove(2));
        }
        [Fact]
        public void ElementIndexTest()
        {
            var list = new List<int>() { 1, 2 };
            Assert.Equal(2, list.IndexOf(2));
            Assert.Equal(0, list.IndexOf(5));
        }
        [Fact]
        public void RemoveAtTest()
        {
            var list = new List<int>() { 1, 2, 3, 4 };
            list.RemoveAt(2);
            list.RemoveAt(3);
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void InsertAtTest()
        {
            var list = new List<int>() { 1, 2, 3 };
            list.Insert(1, 5);
            Assert.Equal(4, list.Count);
        }
        [Fact]
        public void CopyToTest()
        {
            int[] firstList = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] secondList = new int[] { 10, 20, 30 };
            secondList.CopyTo(firstList, 2);
            Assert.Equal(new int[] { 1, 2, 10, 20, 30, 6 }, firstList);
        }
        [Fact]
        public void InsertThrowsArgumentException()
        {
            var list = new List<int>() { 1, 2, 3 };
            Assert.Throws<ArgumentException>(() => list.Insert(4, 3));
        }
        [Fact]
        public void RemoveAtThrowsArgumentException()
        {
            var list = new List<int>() { 1, 2, 3, 4};
            Assert.Throws<ArgumentException>(() => list.RemoveAt(10));
        }

    }
}
