using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace List
{
    [TestClass]
    public class ListTests
    {
        [Fact]
        public void ListIsEmpty()
        {
            var list = new List<int>();
            Xunit.Assert.Equal(0, list.Count);
        }
        [Fact]
        public void AddElementsToList()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            Xunit.Assert.Equal(2, list.Count);
        }
        [Fact]
        public void ClearList()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            Xunit.Assert.Equal(2, list.Count);
            list.Clear();
            Xunit.Assert.Equal(0, list.Count);
        }
        [Fact]
        public void CheckIfListContainsElement()
        {
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Xunit.Assert.True(list.Contains(2));
            Xunit.Assert.False(list.Contains(4));
        }

    }
}
