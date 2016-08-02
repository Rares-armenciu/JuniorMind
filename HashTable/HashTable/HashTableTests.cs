using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HashTable
{
    public class HashTableTests
    {
        [Fact]
        public void AddElements()
        {
            var table = new HashTable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Sergiu");
            Assert.Equal(2, table.Count);
        }
        [Fact]
        public void ClearListTest()
        {
            var table = new HashTable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Sergiu");
            table.Clear();
            Assert.Equal(0, table.Count);
        }
        [Fact]
        public void TableContainsElement()
        {
            var table = new HashTable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Sergiu");
            Assert.True(table.Contains(new KeyValuePair<int, string> (1, "Rares")));
            Assert.True(table.ContainsKey(1));
            Assert.False(table.ContainsKey(5));
        }
        [Fact]
        public void RemoveElementFromTable()
        {
            var table = new HashTable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Sergiu");
            table.Remove(2);
            Assert.Equal(1, table.Count);
            table.Remove(new KeyValuePair<int, string>(1, "Rares"));
            Assert.Equal(0, table.Count);
        }
    }
}
