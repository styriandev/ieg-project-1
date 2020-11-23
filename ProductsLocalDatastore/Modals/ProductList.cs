using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsLocalDatastore.Modals
{
    public class ProductList
    {
        public List<Product> Products { get; set; }

        public ProductList()
        {
            this.Products = new List<Product>();
            this.Products.Add(new Product("Cooles Handy"));
            this.Products.Add(new Product("Whatever"));
        }
    }
}
