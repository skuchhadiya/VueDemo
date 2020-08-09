using API.Factory;
using Podium.Core;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Factory.Products
{
    public class Product90 : IProductFactory
    {
        private readonly IProduct _products;

        public Product90(IProduct products)
        {
            this._products = products;
        }
        public IEnumerable<Product> GetProducts()
        {
            return this._products.GetAllProducts().Where(x => x.LoanToValuePercentage == 90).AsEnumerable();
        }
    }
}
