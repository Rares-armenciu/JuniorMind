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
            char[] password = GeneratePassword(settings, 0, 0, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 0, 0, settings));
        }
        [TestMethod]
        public void SmallAndCapitalLetters()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.capitalLetters;
            char[] password = GeneratePassword(settings, 3, 0, 7);
            Assert.IsTrue(CheckPasswordComponence(password, 3, 0, settings));
        }
        [TestMethod]
        public void SmallLettersAndDigits()
        {
            PasswordSettings settings = PasswordSettings.smallLetters | PasswordSettings.digits;
            char[] password = GeneratePassword(settings, 0, 2, 5);
            Assert.IsTrue(CheckPasswordComponence(password, 0, 2, settings));
        }
        [TestMethod]
        public void TestForPasswordCheck()
        {
            Assert.IsTrue(CheckPasswordComponence(new char[] { 'a', 'b', 'c' }, 0, 0, PasswordSettings.smallLetters));
        }

        private bool CheckPasswordComponence(char[] password, int capitalLetters, int digitsNumber, PasswordSettings settings)
        {
            int counter = 0;
            int counter2 = 0;
            int counter3 = 0;
            string listOfCharacters = StringCreation(PasswordSettings.smallLetters);
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                    counter2++;
                if (password[i] >= '0' && password[i] <= '9')
                    counter3++;
                for (int j = 0; j < listOfCharacters.Length; j++)
                    if (password[i] == listOfCharacters[j])
                    {
                        counter++;
                        break;
                    }
            }
            return ((counter2 == capitalLetters) && (counter3==digitsNumber));
        }

        char[] GeneratePassword(PasswordSettings settings, int capitalLetters, int digitsNumber, int passwordLength)
        {
            Random random = new Random();
            char[] finalPassword = new char[passwordLength];
            string chars = StringCreation(settings);
            for (int i = 0; i < finalPassword.Length; i++)
            {
                do
                {
                    finalPassword[i] = chars[random.Next(chars.Length)];
                    capitalLetters = GetLetterCount(finalPassword[i], capitalLetters);
                    digitsNumber = GetDigitsCount(finalPassword[i], digitsNumber);
                } while (capitalLetters + digitsNumber > finalPassword.Length - i - 1 || capitalLetters < 0 || digitsNumber < 0);
            }
            return finalPassword;
        }

        private int GetLetterCount(char passwordCharacter, int actualNumber)
        {
            if ((passwordCharacter >= 'A' && passwordCharacter <= 'Z'))
                return actualNumber-1;
            if (passwordCharacter >= 'a' && passwordCharacter <= 'z' && actualNumber < 0)
                return 0;
            return actualNumber;
        }
        private int GetDigitsCount(char passwordCharacter, int actualNumber)
        {
            if (passwordCharacter >= '0' && passwordCharacter <= '9')
                return actualNumber - 1;
            if (passwordCharacter >= 'a' && passwordCharacter <= 'z' && actualNumber < 0)
                return 0;
            return actualNumber;
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
