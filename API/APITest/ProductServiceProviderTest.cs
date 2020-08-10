using API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Podium.Core;
using Podium.Core.ViewModels;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace APITest
{
    [TestClass]
    public class ProductServiceProviderTest
    {
        
        [TestMethod]
        public void GetAvailableProduct_Should_Return_Available_Products_LTV90()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("1990-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 10001 };
            var expect = products.GetAllProducts().Where(x => x.LoanToValuePercentage == 90).AsEnumerable();
            var result = service.GetAvailableProduct(terms);
            
            Assert.AreEqual(expect.Count()==1, result.Count()==1);
            Assert.AreEqual(expect.ElementAt(0).LoanToValuePercentage, result.ElementAt(0).LoanToValuePercentage);


        }

        [TestMethod]
        public void GetAvailableProduct_Should_Return_Available_Products_LTV60_And90()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("1990-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 40001 };
            var expect = products.GetAllProducts();
            var result = service.GetAvailableProduct(terms);

            Assert.AreEqual(expect.Count() == 3, result.Count() == 3);
            Assert.AreEqual(expect.ElementAt(0).LoanToValuePercentage, result.ElementAt(0).LoanToValuePercentage);

        }

        [TestMethod]
        public void GetAvailableProduct_Should_Not_Return_Available_Products_if_ltv_above_90()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("1990-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 9999 };
            var result = service.GetAvailableProduct(terms);

            Assert.AreEqual(null, result);
           

        }

        [TestMethod]
        public void GetAvailableProduct_Should_Not_Return_Available_Products_if_ltv_equals_90()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("1990-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 10000 };
            var result = service.GetAvailableProduct(terms);

            Assert.AreEqual(null, result);


        }
        [TestMethod]
        public void GetAvailableProduct_Should_Not_Return_Available_Products_if_user_under_18()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("2010-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 45000 };
            var result = service.GetAvailableProduct(terms);

            Assert.AreEqual(null, result);


        }
        [TestMethod]
        public void GetAvailableProduct_Should__Return_Available_Products_if_user_over_18()
        {
            IProduct products = new InMemoryProduct();
            IUser users = new InMemoryUser();
            User newUser = new User() { Id = 0, FirstName = "Sanjay", LastName = "xxx", DOB = DateTime.Parse("1999-05-05"), Email = "xyx@xyz.com" };
            users.AddUser(newUser);
            ProductServiceProvider service = new ProductServiceProvider(products, users);
            ProductSearchTerms terms = new ProductSearchTerms() { UserID = 1, PropertyValue = 100000, DepositeAmount = 45000 };
            var result = service.GetAvailableProduct(terms);

            Assert.AreNotEqual(null, result);


        }
    }
}
