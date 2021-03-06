﻿using System;
using Xunit;

namespace Hashtable
{
    public class HashtableTests
    {
        [Fact]
        public void CountElementsTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            Assert.Equal(3, table.Count);
        }

        [Fact]
        public void ContainsKeyTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            Assert.Equal(true, table.ContainsKey(2));
        }
        
        [Fact]
        public void RemoveKeyTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            table.Remove(3);
            Assert.Equal(2, table.Count);
        }
        
        [Fact]
        public void ClearTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            table.Clear();
            Assert.Equal(0, table.Count);
        }

        [Fact]
        public void GetValueTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            Assert.Equal("Rares", table[1]);
        }

        [Fact]
        public void SetValueTest()
        {
            var table = new Hashtable<int, string>();
            table.Add(1, "Rares");
            table.Add(2, "Andrei");
            table.Add(3, "Radu");
            table[4] = "Bogdan";
            Assert.Equal(4, table.Count);
        }
    }
}
