using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    public struct PasswordSettings
    {
        public int smallLetters, capitalLetters, digits, symbols;
        public bool noSimilarCharacters, noAmbiguousChars;
        public PasswordSettings(int a, int b, int c, int d, bool similar, bool ambiguous)
        {
            smallLetters = a;
            capitalLetters = b;
            digits = c;
            symbols = d;
            noSimilarCharacters = similar;
            noAmbiguousChars = ambiguous;
        }
    }
    [TestClass]
    public class Password
    {
        [TestMethod]
        public void SmallLettersOnly()
        {
            PasswordSettings settings = new PasswordSettings(5, 0, 0, 0, false, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            PasswordSettings settings = new PasswordSettings(4, 3, 0, 0, false, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void SmallLettersAndDigits()
        {
            PasswordSettings settings = new PasswordSettings(3, 0, 2, 0, false, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void TestForPasswordCheck()
        {
            Assert.IsTrue(CheckPasswordComponence("abc", new PasswordSettings(3, 0, 0, 0, false, false)));
        }
        [TestMethod]
        public void SmallLettersCapitalLettersAndDigits()
        {
            PasswordSettings settings = new PasswordSettings(2, 2, 2, 0, false, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void SmallLettersAndSymbols()
        {
            PasswordSettings settings = new PasswordSettings(3, 0, 0, 3, false, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void PasswordWithoutSimilarCharacters()
        {
            PasswordSettings settings = new PasswordSettings(2, 2, 2, 2, true, false);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        [TestMethod]
        public void PasswordWithoutAmbiguousSymbols()
        {
            PasswordSettings settings = new PasswordSettings(3, 0, 0, 10, false, true);
            string password = GeneratePassword(settings);
            Assert.IsTrue(CheckPasswordComponence(password, settings));
        }
        private bool CheckPasswordComponence(string password, PasswordSettings settings)
        {
            int capitalLettersCount = 0;
            int digitsCount = 0;
            char[] similarCharacters = { 'l', '1', 'I', 'O', 'o', '0' };
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    capitalLettersCount++;
                if (password[i] >= '0' && password[i] <= '9')
                    digitsCount++;
                if (settings.noSimilarCharacters && (password[i] == 'O' || password[i] == 'I'))
                    capitalLettersCount--;
                if (settings.noSimilarCharacters && (password[i] == '0' || password[i] == '1'))
                    digitsCount--;
            }
            return ((capitalLettersCount == settings.capitalLetters) && (digitsCount == settings.digits) && (CountSymbols(password, settings.noAmbiguousChars) == settings.symbols));
        }
      
        string GeneratePassword(PasswordSettings settings)
        {
            string password = null;
            password += GetRandomString('a', 'z', settings.smallLetters, settings.noSimilarCharacters) + 
                GetRandomString('A', 'Z', settings.capitalLetters, settings.noSimilarCharacters) +
                GetRandomString('0', '9', settings.digits, settings.noSimilarCharacters) + GetRandomSymbols(settings.symbols, settings.noAmbiguousChars);
            return password;
        }

        private string GetRandomString(int startPosition, int endPosition, int number, bool noSimilarCharacters)
        {
            string generatedChars = null;
            Random r = new Random();
            char[] similarCharacters = { 'l', '1', 'I', 'O', 'o', '0'};
            for (int i = 0; i < number; i++)
            {
                generatedChars += (char)(r.Next(startPosition, endPosition));
                if(noSimilarCharacters)
                {
                    generatedChars = generatedChars.TrimEnd(similarCharacters);
                    if ((i + 1) != generatedChars.Length)
                        i--;
                }
            }
            return generatedChars;
        }
        string GetRandomSymbols(int numberOfSymbols, bool noAmbiguousSymbols)
        {
            string generatedSymbols = null;
            string symbolList = null;
            Random r = new Random();
            string[] ambiguousSymbols = { "{", "}", "[", "]", "(", ")", "/", "'", "~", ",", ";", ".", "<", ">" };
            symbolList += GetStringFromInterval('!', '/') + GetStringFromInterval(':', '@') + GetStringFromInterval('[', '_') + GetStringFromInterval('{', '~');
            if (noAmbiguousSymbols)
                for (int i = 0; i < ambiguousSymbols.Length; i++)
                    symbolList = symbolList.Replace(ambiguousSymbols[i], "");
            for (int i = 0; i < numberOfSymbols; i++)
            {
                generatedSymbols += symbolList[r.Next(symbolList.Length)];
            }
                return generatedSymbols;
        }
        string GetStringFromInterval(int startPosition, int endPosition)
        {
            string finalString = null;
            for (int i = startPosition; i <= endPosition; i++)
                finalString += (char)(i);
            return finalString;
        }
        int CountSymbols(string password, bool noAmbiguousSymbols)
        {
            string symbolList = null;
            int counter = 0;
            string[] ambiguousSymbols = { "{", "}", "[", "]", "(", ")", "/", "'", "~", ",", ";", ".", "<", ">" };
            symbolList += GetStringFromInterval('!', '/') + GetStringFromInterval(':', '@') + GetStringFromInterval('[', '_') + GetStringFromInterval('{', '~');
            if(noAmbiguousSymbols)
                for(int i=0; i<ambiguousSymbols.Length; i++)
                    symbolList = symbolList.Replace(ambiguousSymbols[i], "");
            for (int i = 0; i < password.Length; i++)
                for (int j = 0; j < symbolList.Length; j++)
                    if (password[i] == symbolList[j])
                        counter++;
            return counter;
        }
    }
}
