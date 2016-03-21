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
        string FindCommonPrefix(string firstWord, string secondWord)
        {
            char[] prefix = new char[GetShortestLength(firstWord, secondWord)];
            int counter = 0;
            for(int i=0; i<GetShortestLength(firstWord, secondWord); i++)
            {
                if (firstWord[i] == secondWord[i])
                {
                    prefix[i] = firstWord[i];
                    counter++;
                }
            }
            Array.Resize(ref prefix, counter);
            string finalPrefix = new string(prefix);
            return finalPrefix;
        }

        private int GetShortestLength(string firstWord, string secondWord)
        {
            if (firstWord.Length > secondWord.Length)
                return secondWord.Length;
            return firstWord.Length;
        }
    }
}
