using Podium.Core;
using Podium.Core.Enums;
using Podium.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podium.Data
{
    //I am considring this as Inmemory database 
    public interface IProduct
    {

        IEnumerable<Product> GetAllProducts();

    }
    public class InMemoryProduct : IProduct
    {
        readonly List<Product> Products;
        public InMemoryProduct()
        {
            Products = new List<Product>()
            {
                new Product{ Lender ="Bank A", InterestRate =2, MortgageType = MortgageTypeEnum.Variable, LoanToValuePercentage = 60},
                new Product{ Lender ="Bank B", InterestRate =3, MortgageType = MortgageTypeEnum.Fixed, LoanToValuePercentage = 60},
                new Product{ Lender ="Bank C", InterestRate =4, MortgageType = MortgageTypeEnum.Variable, LoanToValuePercentage = 90},
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return from r in Products
                   orderby r.Lender
                   select r;
        }
    }
}
