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
        private readonly decimal _ltv;
        private readonly IProductFactory _factory60;
        private readonly IProductFactory _factory90;

        public ProductFactory(IProduct products, decimal ltv)
        {
            _products = products;
            this._ltv = ltv;
            _factory60 = new Product60(_products);
            _factory90 = new Product90(_products);
        }
        public IEnumerable<Product> GetProducts()
        {
            if (_ltv < 60)
            {
                return (_factory60.GetProducts().Concat(_factory90.GetProducts()));
            }
            else if (_ltv < 90)
                return  _factory90.GetProducts();
            return null;
        }
    }
}
