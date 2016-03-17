using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz
{
    [TestClass]
    public class FizzBuzz
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Fizz", CheckFizzBuzz(9));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("FizzBuzz", CheckFizzBuzz(15));
        }
        string CheckFizzBuzz(int number)
        {
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";
            else
                return "No FizzBuzz";
        }
    }
}
