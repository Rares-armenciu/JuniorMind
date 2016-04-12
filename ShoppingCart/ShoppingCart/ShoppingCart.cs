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
        [TestMethod]
        public void ProductWithLowestPrice()
        {
            Product[] productList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5), new Product(3, 1) };
            Assert.AreEqual(productList[3], GetCheapestProduct(productList));
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
        Product GetCheapestProduct(Product[] productList)
        {
            int lowestPrice = productList[0].price;
            int productIndex = 0;
            for(int i=1; i<productList.Length; i++)
            {
                if (productList[i].price < lowestPrice)
                {
                    lowestPrice = productList[i].price;
                    productIndex = i;
                }
                    
            }
            return productList[productIndex];
        }
    }
}
