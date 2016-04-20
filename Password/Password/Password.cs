using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    public struct PasswordSettings
    {
        public int smallLetters, capitalLetters, digits, symbols;
        public PasswordSettings(int a, int b, int c, int d)
        {
            smallLetters = a;
            capitalLetters = b;
            digits = c;
            symbols = d;
        }
    }
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void SmallLettersOnly()
        {
            PasswordSettings settings = new PasswordSettings(5, 0, 0, 0);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            PasswordSettings settings = new PasswordSettings(4, 3, 0, 0);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void SmallLettersAndDigits()
        {
            PasswordSettings settings = new PasswordSettings(3, 0, 2, 0);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void TestForPasswordCheck()
        {
            Assert.IsTrue(CheckPasswordComponence("abc", new PasswordSettings(3, 0, 0, 0)));
        }
        [TestMethod]
        public void SmallLettersCapitalLettersAndDigits()
        {
            PasswordSettings settings = new PasswordSettings(2, 2, 2, 0);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }

        private bool CheckPasswordComponence(string password, PasswordSettings settings)
        {
            int capitalLettersCount = 0;
            int digitsCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    capitalLettersCount++;
                if (password[i] >= '0' && password[i] <= '9')
                    digitsCount++;
            }
            return ((capitalLettersCount == settings.capitalLetters) && (digitsCount == settings.digits));
        }
      
        string GeneratePassword(PasswordSettings settings)
        {
            string password = null;
            password += GetRandomString('a', 'z', settings.smallLetters) + 
                GetRandomString('A', 'Z', settings.capitalLetters) +
                GetRandomString('0', '9', settings.digits);
            return password;
        }

        private string GetRandomString(int startPosition, int endPosition, int number)
        {
            string generatedChars = null;
            Random r = new Random();
            for (int i = 0; i < number; i++)
                generatedChars += (char)(r.Next(startPosition, endPosition));
            return generatedChars;
        }
    }
}
