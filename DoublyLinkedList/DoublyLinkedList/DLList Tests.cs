using System;
using Xunit;

namespace DoublyLinkedList
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class DLLListTests
    {
        [Fact]
        public void AddItemsTest()
        {
            var dlList = new DLList<int> { 1, 2 };
            Assert.Equal(2, dlList.Count);
        }
        [Fact]
        public void ListIsEmpty()
        {
            var list = new DLList<int>();
            Assert.True(list.IsEmpty());
        }
        [Fact]
        public void AddFirstTest()
        {
            var list = new DLList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ListContainsIntegerOne()
        {
            var list = new DLList<int> { 1, 2, 3 };
            Assert.True(list.Contains(3));
        }
        [Fact]
        public void ElementIsRemovedFromList()
        {
            var list = new DLList<int> { 1, 2, 3 };
            list.Remove(1);
            Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ListIsCleared()
        {
            var list = new DLList<int> { 1, 2, 3 };
            list.Clear();
            Assert.Equal(0, list.Count);
        }

    }
}
