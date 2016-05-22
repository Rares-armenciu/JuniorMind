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
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ClearList()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(2, list.Count);
            list.Clear();
            Assert.Equal(0, list.Count);
        }
        [Fact]
        public void CheckIfListContainsElement()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Contains(2));
            Assert.False(list.Contains(4));
        }
        [Fact]
        public void RemoveItemFromList()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.Remove(2));
        }
        [Fact]
        public void ElementIndexTest()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            Assert.Equal(2, list.IndexOf(2));
            Assert.Equal(0, list.IndexOf(5));
        }
        [Fact]
        public void RemoveAtTest()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.RemoveAt(2);
            list.RemoveAt(3);
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void InsertAtTest()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Insert(1, 5);
            Assert.Equal(4, list.Count);
        }
    }
}
