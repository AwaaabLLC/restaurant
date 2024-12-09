using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;

namespace IDataAcessLayer
{
    public interface IProductsAccessor
    {
        bool inserProduct(Product product);
        List<Product> selectAllProducts();
    }
}
