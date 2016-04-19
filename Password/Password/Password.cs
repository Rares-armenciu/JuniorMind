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
        public void SmallLettersOnly()
        {
            PasswordSettings settings = PasswordSettings.smallLetters;
            string password = GeneratePassword(settings, 0, 0, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 0, 0));
        }
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.capitalLetters;
            string password = GeneratePassword(settings, 3, 0, 7);
            Assert.IsTrue(CheckPasswordComponence(password, 3, 0));
        }
        [TestMethod]
        public void SmallLettersAndDigits()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.digits;
            string password = GeneratePassword(settings, 0, 2, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 0, 2));
        }
        [TestMethod]
        public void TestForPasswordCheck()
        {
            Assert.IsTrue(CheckPasswordComponence("abc", 0, 0));
        }
        [TestMethod]
        public void SmallLettersCapitalLettersAndDigits()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.capitalLetters | PasswordSettings.digits;
            string password = GeneratePassword(settings, 2, 2, 6);
            Assert.IsTrue(CheckPasswordComponence(password, 2, 2));
        }
        private bool CheckPasswordComponence(string password, int capitalLetters, int digitsNumber)
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
            return ((capitalLettersCount == capitalLetters) && (digitsCount==digitsNumber));
        }
      
        string GeneratePassword(PasswordSettings settings, int capitalLetters, int digitNumber, int passwordLength)
        {
            string password = null;
            int smallLetters = passwordLength - capitalLetters - digitNumber;
            password += GetRandomString(PasswordSettings.smallLetters, smallLetters) + 
                GetRandomString(PasswordSettings.capitalLetters, capitalLetters) +
                GetRandomString(PasswordSettings.digits, digitNumber);
            return password;
        }

        private string GetRandomString(PasswordSettings settings, int number)
        {
            string generatedChars = null;
            Random r = new Random();
            int startPosition = 0;
            int endPosition = 0;
            if ((settings & PasswordSettings.smallLetters) != 0)
            {
                startPosition = 97;
                endPosition = 122;
            }
            if((settings & PasswordSettings.capitalLetters) != 0)
            {
                startPosition = 65;
                endPosition = 90;
            }
            if((settings & PasswordSettings.digits) != 0)
            {
                startPosition = 48;
                endPosition = 57;
            }
            for (int i = 0; i < number; i++)
                generatedChars += (char)(r.Next(startPosition, endPosition));
            return generatedChars;
        }



        /*string StringCreation(PasswordSettings settings)
        {
            string smallLetters = null;
            string capitalLetters = null;
            string digits = null;
            for (int i=0; i<26; i++)
            {
                smallLetters += (char)(i + 97);
                capitalLetters += (char)(i + 65);
                if (i < 10)
                    digits += (char)(i + 48);
            }
            string finalString = null;
            if ((settings & PasswordSettings.smallLetters) != 0)
                finalString = finalString + smallLetters;
            if ((settings & PasswordSettings.capitalLetters) != 0)
                finalString = finalString + capitalLetters;
            if ((settings & PasswordSettings.digits) != 0)
                finalString = finalString + digits;
            return finalString;
        }*/
    }
}
