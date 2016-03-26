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
            int factorial = 1;
            char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            for (int i = 0; i < letters.Length; i++)
                factorial *= Factorial(GetRepeatingLetter(letters[i], word));
            return Factorial(word.Length)/factorial;
        }

        private int Factorial(int length)
        {
            int result = 1;
            for (int i = 2; i <= length; i++)
                result *= i;
            return result;
        }
        int GetRepeatingLetter(char letterToCompare, string word)
        {
            int counter = 0;
            for (int i = 0; i < word.Length; i++)
                if (letterToCompare == word[i])
                    counter++;
            return counter;
        }
    }
}
