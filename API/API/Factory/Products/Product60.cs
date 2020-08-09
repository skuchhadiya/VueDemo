using API.Factory;
using Podium.Core;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Factory.Products
{
    public class Product60 : IProductFactory
    {
        private readonly IProduct _products;

        public Product60(IProduct products)
        {
            this._products = products;
        }
        public IEnumerable<Product> GetProducts()
        {
            return this._products.GetAllProducts().Where(x => x.LoanToValuePercentage == 60).AsEnumerable();
        }
    }
}
