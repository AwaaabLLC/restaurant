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
        Product selectProductById(int? id);
        bool inserProduct(Product product);
        List<Product> selectAllProducts();
        int updateProduct(Product product);
        bool deleteProductById(int id);
    }
}
