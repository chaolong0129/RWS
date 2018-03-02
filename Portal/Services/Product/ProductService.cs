using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public class ProductService : IProductService
    {
        public List<Product> GetSomeProducts()
        {
            return new List<Product> {
                new Product {ID = 1, Name = "Laptop", Price = 320.00},
                new Product {ID = 2, Name = "SmartPhone", Price = 206.00}
            };
        }
    }
}
