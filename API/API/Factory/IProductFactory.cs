using Microsoft.Extensions.DependencyModel;
using Podium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Factory
{
    public interface IProductFactory
    {
        IEnumerable<Product> GetProducts();
    }
}
