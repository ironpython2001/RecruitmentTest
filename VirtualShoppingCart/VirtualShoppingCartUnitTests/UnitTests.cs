using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using VirtualShoppingCartDB;

namespace VirtualShoppingCartUnitTests
{
    [TestClass]
    public class UnitTests
    {
        private Cart _cart = new Cart();
        private List<Product> products = new List<Product>();

        public UnitTests()
        {
            var prod1 = new Product()
            {
                ProductID = 1,
                ProductName = "abc",
                ImageUrl = "http://cart.com/one.jpg",
                Price = 100.02
            };
            this._cart.AddItem(new CartItem(prod1, 2));

            var prod2 = new Product()
            {
                ProductID = 2,
                ProductName = "xyz",
                ImageUrl = "http://cart.com/two.jpg",
                Price = 105.00
            };
            this._cart.AddItem(new CartItem(prod2, 1));


        }

        [TestMethod]
        public void AddItemsToShoppingCart()
        {
            var prod3 = new Product()
            {
                ProductID = 3,
                ProductName = "pqr",
                ImageUrl = "http://cart.com/three.jpg",
                Price = 200.00
            };
            this._cart.AddItem(new CartItem(prod3, 1));
            Assert.IsTrue(this._cart.Items.Count == 3);
        }

        [TestMethod]
        public void UpdateItemsToShoppingCart()
        {
            //take second element
            var nStep = 1;
            var cartItem = this._cart.Items.Where((x, i) => i % nStep == 0).First();
            this._cart.Update(cartItem,2);
            Assert.IsTrue(cartItem.Quantity == 3);
        }

        [TestMethod]
        public void DeleteItemsFromShoppingCart()
        {

        }

        [TestMethod]
        public void CheckOffersAppliedOnProduct1()
        {

        }



    }
}
