using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Podium.Core.ViewModels;
using Podium.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public ActionResult Get([FromQuery] ProductSearchTerms searchTerms)
        {
            var result = this._productService.GetAvailableProduct(searchTerms);
            if (result == null)
                return NotFound();
            return Ok(result);

        }
    }
}
