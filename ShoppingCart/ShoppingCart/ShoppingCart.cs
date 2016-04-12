using System;
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
            Product[] productList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5) };
            Assert.AreEqual(35, CalculateShoppingCartPrice(productList));
        }

        private int CalculateShoppingCartPrice(Product[] productList)
        {
            int totalPrice = 0;
            for(int i=0; i<productList.Length; i++)
            {
                Product auxiliaryProduct = productList[i];
                totalPrice += auxiliaryProduct.numberOfProducts * auxiliaryProduct.price;
            }
            return totalPrice;
        }
    }
}
