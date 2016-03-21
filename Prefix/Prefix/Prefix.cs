using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prefix
{
    [TestClass]
    public class Prefix
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("aaa", FindCommonPrefix("aaab", "aaaabbaa"));
        }
        string FindCommonPrefix(string firstString, string secondString)
        {
            return string.Empty;
        }
    }
}
