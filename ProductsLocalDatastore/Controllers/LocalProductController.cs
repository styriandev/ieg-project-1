using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsLocalDatastore.Modals;

namespace ProductsLocalDatastore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class LocalProductController : ControllerBase
    {
        public ProductList ProductList{ get; set; }

        public LocalProductController()
        {
            this.ProductList = new ProductList();
        }

        [HttpGet]
        public IEnumerable<string> GetProducts()
        {
            return this.ProductList.Products.Select(_ => _.NameOfProduct);
        }

        [HttpPost]
        public void PushProduct(Product p)
        {
            this.ProductList.Products.Add(p);
        }
    }
}