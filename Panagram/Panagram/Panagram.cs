using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panagram
{
    [TestClass]
    public class Panagram
    {
        [TestMethod]
        public void TestForPanagram()
        {
            Assert.AreEqual("YES", CheckIfPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void TestForNotPanagram()
        {
            Assert.AreEqual("NO", CheckIfPanagram("This is not a panagram."));
        }
        string CheckIfPanagram(string panagram)
        {
            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                    'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            int[] letterAppearance = new int[26];
            for (int i = 0; i < 26; i++) letterAppearance[i] = 0;
            for(int i=0; i<panagram.Length; i++)
                for(int j=0; j<alphabet.Length; j++)
                    if (panagram[i] == alphabet[j])
                        letterAppearance[j]++;
            int counter = 0;
            for (int i = 0; i < alphabet.Length; i++)
                if (letterAppearance[i] == 0)
                    counter++;
            if (counter == 0)
                return "YES";
            return "NO";
        }
    }
}
