using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lottery
{
    [TestClass]
    public class Lottery
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0.00000007, CalculateLotteryWinChance(6, 6, 49));
        }
        decimal CalculateLotteryWinChance(int hitNumbers, int chosenNumbers, int totalNumbers)
        {
            decimal winChance = Combinations(hitNumbers, chosenNumbers)*Combinations(chosenNumbers-hitNumbers, totalNumbers-chosenNumbers);
            return winChance/Combinations(chosenNumbers, totalNumbers);
        }

        private decimal Combinations(int k, int n)
        {
            if (k == 0 || k == n)
                return 1;
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private int Factorial(int factorialNumber)
        {
            int factorialResult = 1;
            if (factorialNumber == 0 || factorialNumber == 1)
                return 1;
            for (int i = 2; i < factorialNumber + 1; i++)
                factorialResult *= factorialNumber;
            return factorialResult;
        }
    }
}
