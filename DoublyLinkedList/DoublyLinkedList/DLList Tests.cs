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
            Assert.Equal(1, dlList.Count);
        }
    }
}
