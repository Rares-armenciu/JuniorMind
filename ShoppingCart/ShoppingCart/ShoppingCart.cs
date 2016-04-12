﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart
{
    public struct Product
    {
        public int numberOfProducts;
        public int price;
        public Product(int numberOfProducts, int price)
        {
            this.numberOfProducts = numberOfProducts;
            this.price = price;
        }
    }

    [TestClass]
    public class ShoppingCart
    {
        [TestMethod]
        public void TotalPriceToPay()
        {
            Product a = new Product(1, 5);
            Product b = new Product(3, 10);
            Product c = new Product(5, 2);
            Assert.AreEqual(45, CalculateShoppingCartPrice(a, b, c));
        }

        private int CalculateShoppingCartPrice(Product a, Product b, Product c)
        {
            int totalPrice = a.numberOfProducts * a.price + b.numberOfProducts * b.price + c.numberOfProducts * c.price;
            return totalPrice;
        }
    }
}
