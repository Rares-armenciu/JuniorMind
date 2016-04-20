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
        [TestMethod]
        public void SmallLettersAndSymbols()
        {
            PasswordSettings settings = new PasswordSettings(3, 0, 0, 3);
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
            return ((capitalLettersCount == settings.capitalLetters) && (digitsCount == settings.digits) && (CountSymbols(password) == settings.symbols));
        }
      
        string GeneratePassword(PasswordSettings settings)
        {
            string password = null;
            password += GetRandomString('a', 'z', settings.smallLetters) + 
                GetRandomString('A', 'Z', settings.capitalLetters) +
                GetRandomString('0', '9', settings.digits) + GetRandomSymbols(settings.symbols);
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
        string GetRandomSymbols(int numberOfSymbols)
        {
            string generatedSymbols = null;
            string symbolList = null;
            Random r = new Random();
            symbolList += GetStringFromInterval('!', '/') + GetStringFromInterval(':', '@') + GetStringFromInterval('[', '_') + GetStringFromInterval('{', '~');
            for(int i=0; i<numberOfSymbols; i++)
                generatedSymbols += symbolList[r.Next(symbolList.Length)];
            return generatedSymbols;
        }
        string GetStringFromInterval(int startPosition, int endPosition)
        {
            string finalString = null;
            for (int i = startPosition; i <= endPosition; i++)
                finalString += (char)(i);
            return finalString;
        }
        int CountSymbols(string password)
        {
            string symbolList = null;
            int counter = 0;
            symbolList += GetStringFromInterval('!', '/') + GetStringFromInterval(':', '@') + GetStringFromInterval('[', '_') + GetStringFromInterval('{', '~');
            for (int i = 0; i < password.Length; i++)
                for (int j = 0; j < symbolList.Length; j++)
                    if (password[i] == symbolList[j])
                        counter++;
            return counter;
        }
    }
}
