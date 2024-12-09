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
        public bool inserProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> selectAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
