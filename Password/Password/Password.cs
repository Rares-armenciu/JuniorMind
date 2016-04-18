using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [Flags]
    public enum PasswordSettings
    {
        smallLetters = 0x1, capitalLetters = 0x2, digits = 0x4, symbols = 0x8, noSimilarChar = 0x10, noAmbigouosChar = 0x20
    }
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void TestForSmallLettersOnly()
        {
            PasswordSettings settings = PasswordSettings.smallLetters;
            char[] password = GeneratePassword(settings, 0, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 0, settings));
        }
        [TestMethod]
        public void TestForSmallAndCapitalLetters()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.capitalLetters;
            char[] password = GeneratePassword(settings, 3, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 3, settings));
        }

        private bool CheckPasswordComponence(char[] password, int capitalLetters, PasswordSettings settings)
        {
            int counter = 0;
            int counter2 = 0;
            string listOfCharacters = StringCreation(settings ^ PasswordSettings.capitalLetters);
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = 0; j < listOfCharacters.Length; j++)
                    if (password[i] == listOfCharacters[j])
                    {
                        counter++;
                        break;
                    }
                if (password[i] >= 'A' && password[i] <= 'Z')
                    counter2++;
            }
            return (counter2 == capitalLetters);
        }

        char[] GeneratePassword(PasswordSettings settings, int capitalLetters, int passwordLength)
        {
            Random random = new Random();
            char[] finalPassword = new char[passwordLength];
            string chars = StringCreation(settings);
            for (int i = 0; i < finalPassword.Length; i++)
            {
                do
                {
                    finalPassword[i] = chars[random.Next(chars.Length)];
                    if (finalPassword[i] >= 'A' && finalPassword[i] <= 'Z')
                        capitalLetters--;
                } while (capitalLetters > finalPassword.Length - i - 1);
            }
            return finalPassword;
        }

        string StringCreation(PasswordSettings settings)
        {
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string finalString = null;
            if ((settings & PasswordSettings.smallLetters) != 0)
                finalString = finalString + smallLetters;
            if ((settings & PasswordSettings.capitalLetters) != 0)
                finalString = finalString + capitalLetters;
            if ((settings & PasswordSettings.digits) != 0)
                finalString = finalString + digits;
            return finalString;
        }
    }
}
