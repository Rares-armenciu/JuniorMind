using System;
using Xunit;

namespace Hashtable
{
    public class HashtableTests
    {
        [Fact]
        public void TestMethod1()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            table.Remove(1);
            Assert.Equal(2, table.Count);
        }
    }
}
