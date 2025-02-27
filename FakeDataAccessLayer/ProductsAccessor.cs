using DataObjectLayer;
using IDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeDataAccessLayer
{
    public class ProductsAccessor : IProductsAccessor
    {
        public Product selectProductById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool inserProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> selectAllProducts()
        {
            throw new NotImplementedException();
        }

        public int updateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool deleteProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
