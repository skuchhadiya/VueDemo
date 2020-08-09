using API.Factory.Products;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Podium.Core;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Factory
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProduct _products;
        private readonly IProductFactory _factory;

        public ProductFactory(IProduct products, decimal ltv)
        {
            _products = products;
            
            if (ltv < 60)
                _factory = new Product60(_products);

            else if (ltv < 90)
                _factory = new Product90(_products);
        }
        public IEnumerable<Product> GetProducts()
        {
            if(_factory !=null)
                return _factory.GetProducts();
            return null;
        }
    }
}
