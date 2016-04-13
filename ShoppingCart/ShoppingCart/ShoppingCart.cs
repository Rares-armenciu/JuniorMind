using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart
{
    [TestClass]
    public class ShoppingCart
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
        [TestMethod]
        public void MostExpensiveProductIsEliminated()
        {
            Product[] productList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5), new Product(3, 1) };
            Product[] newProductList = new Product[] { new Product(2, 5), new Product(3, 5), new Product(3, 1) };
            CollectionAssert.AreEqual(newProductList, EliminateMostExpensiveProduct(productList));
        }
        [TestMethod]
        public void TestForAddingOneMoreProduct()
        {
            Product[] productList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5), new Product(3, 1) };
            Product[] newProductList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5), new Product(3, 1) , new Product(2, 7)};
            Assert.AreEqual(newProductList, AddNewProductToList(newProductList, new Product(2, 7)));
        }
        [TestMethod]
        public void MediumPriceOfTheProducts()
        {
            Product[] productList = new Product[] { new Product(1, 10), new Product(2, 5), new Product(3, 5), new Product(5, 4) };
            Assert.AreEqual(6, GetMediumPrice(productList));
        }
        private int CalculateShoppingCartPrice(Product[] productList)
        {
            int totalPrice = 0;
            for (int i = 0; i < productList.Length; i++)
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
            for (int i = 1; i < productList.Length; i++)
            {
                if (productList[i].price < lowestPrice)
                {
                    lowestPrice = productList[i].price;
                    productIndex = i;
                }

            }
            return productList[productIndex];
        }
        Product[] EliminateMostExpensiveProduct(Product[] productList)
        {
            int highestPrice = productList[0].price;
            int productIndex = 0;
            for (int i = 1; i < productList.Length; i++)
            {
                if (productList[i].price > highestPrice)
                {
                    highestPrice = productList[i].price;
                    productIndex = i;
                }
            }
            for (int i = productIndex; i < productList.Length-1; i++)
                productList[i] = productList[i + 1];
            Array.Resize(ref productList, productList.Length - 1);
            return productList;
        }
        Product[] AddNewProductToList(Product[] productList, Product newProduct)
        {
            Product[] newProductList = new Product[productList.Length + 1];
            newProductList = productList;
            newProductList[newProductList.Length - 1] = newProduct;
            return newProductList;
        }
        int GetMediumPrice(Product[] productList)
        {
            int totalPrice = 0;
            for(int i=0; i<productList.Length; i++)
            {
                totalPrice += productList[i].price;
            }
            return totalPrice / productList.Length;
        }
    }
}
