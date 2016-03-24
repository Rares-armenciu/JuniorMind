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
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("", FindCommonPrefix("abcd", "efgh"));
        }
        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("", FindCommonPrefix("xaa", "yaa"));
        }
        string FindCommonPrefix(string firstWord, string secondWord)
        {
            string prefix = string.Empty;
            for(int i=0; i<GetShortestLength(firstWord, secondWord); i++)
            {
                if (firstWord[i] == secondWord[i])
                {
                    prefix = prefix + firstWord[i];
                }
                else
                    break;
            }
            return prefix;
        }

        private int GetShortestLength(string firstWord, string secondWord)
        {
            if (firstWord.Length > secondWord.Length)
                return secondWord.Length;
            return firstWord.Length;
        }
    }
}
