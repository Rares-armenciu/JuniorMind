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
        public void TestMethod1()
        {
            PasswordSettings settings = PasswordSettings.smallLetters;
            char[] password = GeneratePassword(settings, 5);
            Assert.IsTrue(CheckPasswordComponence(password));
        }

        private bool CheckPasswordComponence(char[] password)
        {
            for (int i = 0; i < password.Length; i++)
                if (password[i] >= 'a' && password[i] <= 'z')
                    return true;
            return false;
        }

        char[] GeneratePassword(PasswordSettings settings, int passwordLength)
        {
            Random random = new Random();
            char[] finalPassword = new char[passwordLength];
            var chars = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < finalPassword.Length; i++)
            {
                finalPassword[i] = chars[random.Next(chars.Length)];
            }
            return finalPassword;
        }
    }
}
