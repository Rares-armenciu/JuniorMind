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
            Assert.AreEqual(true, CheckIfPanagram("The quick brown fox jumps over the lazy dog"));
        }
        [TestMethod]
        public void TestForNotPanagram()
        {
            Assert.AreEqual(false, CheckIfPanagram("This is not a panagram."));
        }
        bool CheckIfPanagram(string panagram)
        {
            bool[] letterAppearance = new bool[26];
            for(int i=0; i<panagram.Length; i++)
            {
                char character = char.ToUpper(panagram[i]);
                if(character >= 'A' && character <= 'Z')
                {
                    int position = character - 'A';
                    letterAppearance[position] = true;
                }
            }
            for (int i = 0; i < letterAppearance.Length; i++)
                if (!letterAppearance[i])
                    return false;
            return true;
        }
    }
}
