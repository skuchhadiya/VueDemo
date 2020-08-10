using API.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Podium.Core;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APITest
{
    [TestClass]
    public class ProductFactoryTest
    {
        [TestMethod]
        public void GetProducts_Should_Return_Available_Products_90()
        {
            IProduct products = new InMemoryProduct();
            ProductFactory factory = new ProductFactory(products, 89);
            var expect = 1;
            var result = factory.GetProducts();

            Assert.AreEqual(expect, result.Count() );
        }

        [TestMethod]
        public void GetProducts_Should_Not_Return_Available_Products_90()
        {
            IProduct products = new InMemoryProduct();
            ProductFactory factory = new ProductFactory(products, 91);
            var result = factory.GetProducts();

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetProducts_Should_Not_Return_Available_Products_60()
        {
            IProduct products = new InMemoryProduct();
            ProductFactory factory = new ProductFactory(products, 65);
           
            var data = factory.GetProducts();
            var expect = false;
            var result = data.Any(x => x.LoanToValuePercentage == 60);

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void GetProducts_Should_Return_Available_Products_60()
        {
            IProduct products = new InMemoryProduct();
            ProductFactory factory = new ProductFactory(products, 55);

            var data = factory.GetProducts();
            var expect = true;
            var result = data.Any(x => x.LoanToValuePercentage == 60);

            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void GetProducts_Should_Return_Available_Products_60_And_90()
        {
            IProduct products = new InMemoryProduct();
            ProductFactory factory = new ProductFactory(products, 55);

            var data = factory.GetProducts();
            var expect = true;
            var result = data.Any(x => x.LoanToValuePercentage == 60);
            var result2 = data.Any(x => x.LoanToValuePercentage == 90);

            Assert.AreEqual(expect, result);
            Assert.AreEqual(expect, result2);
        }
    }
}
