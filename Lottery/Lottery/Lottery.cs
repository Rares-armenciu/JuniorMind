using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class Lottery
    {
        [TestMethod]
        public void TestForFirstCategory()
        {
            Assert.AreEqual(0.00000007, CalculateLotteryWinChance(6, 6, 49));
        }
        [TestMethod]
        public void TestForSecondCategory()
        {
            Assert.AreEqual(0.00001845, CalculateLotteryWinChance(5, 6, 49));
        }
        [TestMethod]
        public void TestForThirdCategory()
        {
            Assert.AreEqual(0.00096862, CalculateLotteryWinChance(4, 6, 49));
        }
        [TestMethod]
        public void TestForFiveOutOfFourty()
        {
            Assert.AreEqual(0.00000152, CalculateLotteryWinChance(5, 5, 40));
        }
        double CalculateLotteryWinChance(int hitNumbers, int chosenNumbers, int totalNumbers)
        {
            double hitNumbersChance = Combinations(hitNumbers, chosenNumbers);
            hitNumbersChance *= Combinations(chosenNumbers - hitNumbers, totalNumbers - chosenNumbers);
            return Math.Round(hitNumbersChance/Combinations(chosenNumbers, totalNumbers), 8);
        }
        double Combinations(int k, int n)
        {
            if (k == 0 || k == n)
                return 1;
            return Factorial(n)/(Factorial(k)*Factorial(n- k));
        }
        double Factorial(int factorialNumber)
        {
            double factorialResult = 1;
            for (int i = 2; i <= factorialNumber; i++)
                factorialResult *= i;
            return factorialResult;
        }
    }
}
