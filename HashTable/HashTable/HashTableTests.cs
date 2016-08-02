using System;
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
    }
}
