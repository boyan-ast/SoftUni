using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product product;
        private StoreManager manager;

        [SetUp]
        public void Setup()
        {
            this.product = new Product("Pepsi", 3, 1.60m);
            this.manager = new StoreManager();
        }

        [Test]
        public void Constructor_ShouldCreateEmptyCollection_WhenCalled()
        {
            Assert.That(this.manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_ShouldCreateNewCollectionWhenCalled()
        {
            List<Product> list = new List<Product>();

            Assert.That(this.manager.Products, Is.EquivalentTo(list));
        }

        [Test]
        public void AddingProduct_ShouldIncreaseCount()
        {
            this.manager.AddProduct(product);

            Assert.That(this.manager.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddProduct_ShouldThrowException_WhenNullProductGiven()
        {
            Assert.Throws<ArgumentNullException>(() => this.manager.AddProduct(null));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void AddProduct_ShouldThrowException_WhenProductQuantityIsZeroOrNegative(int quantity)
        {
            product = new Product("Test", quantity, 22.60m);

            Assert.Throws<ArgumentException>(() => this.manager.AddProduct(product));
        }

        [Test]
        public void BuyProduct_ShouldThrowException_WhenProductDoesntExist()
        {
            Assert.Throws<ArgumentNullException>(() => this.manager.BuyProduct("Test", 42));
        }
        
        [Test]
        public void BuyPoduct_ShouldThrowException_WhenTheProductQuantityIsLessThanTheGiven()
        {
            this.manager.AddProduct(this.product);

            Assert.Throws<ArgumentException>(() => this.manager.BuyProduct(this.product.Name, this.product.Quantity + 1));
        }

        [Test]
        public void BuyProduct_ShouldReturnFinalPrice_WhenThereIsNoException()
        {
            this.manager.AddProduct(this.product);            

            decimal expectedPrice = this.product.Price * (this.product.Quantity - 1);

            decimal result = this.manager.BuyProduct(this.product.Name, this.product.Quantity - 1);

            Assert.That(result, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void BuyProduct_ShouldDecreaseProductQuantity()
        {
            this.manager.AddProduct(this.product);
            this.manager.BuyProduct(this.product.Name, this.product.Quantity - 1);

            Assert.That(this.product.Quantity, Is.EqualTo(1));
        }

        [Test]
        public void GetTheMostExpensiveProduct_ShouldReturnCorrectResult()
        {
            this.manager.AddProduct(this.product);

            decimal higherPrice = this.product.Price + 10;

            Product expensiveProduct = new Product("Expensive", 10, higherPrice);

            this.manager.AddProduct(expensiveProduct);

            Product result = this.manager.GetTheMostExpensiveProduct();

            Assert.That(result.Name, Is.EqualTo(expensiveProduct.Name));
            Assert.That(result.Price, Is.EqualTo(expensiveProduct.Price));
            Assert.That(result.Quantity, Is.EqualTo(expensiveProduct.Quantity));
        }
    }
}