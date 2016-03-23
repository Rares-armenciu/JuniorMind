using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Anagrams
{
    [TestClass]
    public class Anagrams
    {
        [TestMethod]
        public void TestForOneLetter()
        {
            Assert.AreEqual(1, CalculateNumberOfAnagrams("a"));
        }
        [TestMethod]
        public void TestForFourLetters()
        {
            Assert.AreEqual(24, CalculateNumberOfAnagrams("abcd"));
        }
        [TestMethod]
        public void TestForEightLetters()
        {
            Assert.AreEqual(40320, CalculateNumberOfAnagrams("abcdefgh"));
        }
        int CalculateNumberOfAnagrams(string word)
        {
            return recursiveAnagrams(word.Length);
        }

        private int recursiveAnagrams(int length)
        {
            if (length == 1)
                return 1;
            else
                return length * recursiveAnagrams(length - 1);
        }
    }
}
