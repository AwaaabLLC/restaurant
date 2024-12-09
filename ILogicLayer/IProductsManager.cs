using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace ILogicLayer
{
    public interface IProductsManager
    {
        bool addProduct(Product product);
        List<Product> getAllProducts();
    }
}
