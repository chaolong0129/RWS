using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public interface IProductService
    {
        List<Product> GetSomeProducts();
    }
}
