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
        [TestMethod]
        public void TestForLetterAppearingMoreTimes()
        {
            Assert.AreEqual(3, CalculateNumberOfAnagrams("aab"));
        }
        [TestMethod]
        public void TestForSameLetter()
        {
            Assert.AreEqual(1, CalculateNumberOfAnagrams("aaaa"));
        }
        [TestMethod]
        public void TestForMoreRepeatingLetters()
        {
            Assert.AreEqual(6, CalculateNumberOfAnagrams("aabb"));
        }
        int CalculateNumberOfAnagrams(string word)
        {
            int counter = 1;
            for(int i=0; i<word.Length; i++)
                for(int j=i+1; j<word.Length; j++)
                    if(word[i]==word[j])
                    {
                        counter++;
                        i++;
                    }
            return Factorial(word.Length)/Factorial(counter);
        }

        private int Factorial(int length)
        {
            int result = 1;
            for (int i = 2; i <= length; i++)
                result *= i;
            return result;
        }
    }
}
