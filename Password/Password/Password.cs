using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [Flags]
    public enum PasswordSettings
    {
        smallLetters = 0x1, capitalLetters = 0x2, numbers = 0x4, symbols = 0x8, noSimilarChar = 0x10, noAmbigouosChar = 0x20
    }
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void TestForSmallLettersOnly()
        {
            PasswordSettings settings = PasswordSettings.smallLetters;
            char[] password = GeneratePassword(settings, 5);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void TestForSmallAndCapitalLetters()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.capitalLetters;
            char[] password = GeneratePassword(settings, 5);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }

        private bool CheckPasswordComponence(char[] password, PasswordSettings settings)
        {
            int counter = 0;
            string listOfCharacters = StringCreation(settings);
            for (int i = 0; i < password.Length; i++)
                for(int j=0; j<listOfCharacters.Length; j++)
                    if(password[i] == listOfCharacters[j])
                    {
                        counter++;
                        break;
                    }
            return (counter == password.Length);
        }

        char[] GeneratePassword(PasswordSettings settings, int passwordLength)
        {
            Random random = new Random();
            char[] finalPassword = new char[passwordLength];
            string chars = StringCreation(settings);
            for (int i = 0; i < finalPassword.Length; i++)
            {
                finalPassword[i] = chars[random.Next(chars.Length)];
            }
            return finalPassword;
        }

        string StringCreation(PasswordSettings settings)
        {
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string finalString = null;
            if ((settings & PasswordSettings.smallLetters) != 0)
                finalString = finalString + smallLetters;
            if ((settings & PasswordSettings.capitalLetters) != 0)
                finalString = finalString + capitalLetters;
            return finalString;
        }
    }
}
