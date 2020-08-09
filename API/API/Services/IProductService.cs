using API.Factory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Podium.Core;
using Podium.Core.Utility;
using Podium.Core.ViewModels;
using Podium.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAvailableProduct(ProductSearchTerms searchTerms);
    }
    public class ProductServiceProvider : IProductService
    {
        private readonly IProduct _products;
        private readonly IUser _users;

        //Here we can inject DatabaseContext or individual service to get users and products 
        public ProductServiceProvider(IProduct products, IUser users)
        {
            this._products = products;
            this._users = users;
        }

        public IEnumerable<Product> GetAvailableProduct(ProductSearchTerms searchTerms)
        {
            User user = this._users.GetUser(searchTerms.UserID);
            decimal ltv = PodiumUtility.CalculateLTV(searchTerms.PropertyValue, searchTerms.DepositeAmount);
           
            bool IsUnder18 = PodiumUtility.IsUnder18(user.DOB);
           
            if (IsUnder18)
                return null;

            //possible to add if here 
            //if (ltv < 60)
            //if (ltv < 90)
            //for simplicity

            //factory method to retrive related products as per LTV ratio
            //This is useful when we might need further filter on mortgage type etc

            IProductFactory factory = new ProductFactory(_products, ltv);
            
            return factory.GetProducts();
            
        }

    }
}
