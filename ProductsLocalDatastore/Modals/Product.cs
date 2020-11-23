using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsLocalDatastore.Modals
{
    public class Product
    {
        public string NameOfProduct { get; set; }

        public Product(string name)
        {
            this.NameOfProduct = name;
        }
    }
}
