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
        private List<Product> products = [];
        public ProductsAccessor() 
        {
            addFiveSampleProducts();
        }

        private void addFiveSampleProducts()
        {
            for (int i = 1; i < 6; i++)
            {
                Product product = new();
                product.Id = i;
                product.UPC = "123456789-" + i;
                product.Name = "test" + i;
                product.QTY = (100 + i).ToString();
                product.Price = (100 + i).ToString();
                products.Add(product);
            }
        }

        public bool inserProduct(Product product)
        {
            int prev = products.Count;
            products.Add(product);
            return products.Count - prev == 1;
        }

        public List<Product> selectAllProducts()
        {
            return products;
        }
    }
}
