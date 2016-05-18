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
    }
}
