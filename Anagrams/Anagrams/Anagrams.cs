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
