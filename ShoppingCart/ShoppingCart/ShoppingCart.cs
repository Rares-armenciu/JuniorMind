using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart
{
    public struct Product
    {
        public int numberOfProducts;
        public double price;
        public Product(int numberOfProducts, double price)
        {
            this.numberOfProducts = numberOfProducts;
            this.price = price;
        }
    }

    [TestClass]
    public class ShoppingCart
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product a = new Product(1, 5);
            Product b = new Product(3, 10);
            Product c = new Product(5, 2);
            Assert.AreEqual(45, CalculateShoppingCartPrice(a, b, c));
        }

        private int CalculateShoppingCartPrice(Product a, Product b, Product c)
        {
            return 0;
        }
    }
}
