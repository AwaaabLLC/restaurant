using ILogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer;
using DataAccessLayer;
using IDataAcessLayer;

namespace LogicLayer
{
    public class ProductsManager : IProductsManager
    {
        private IProductsAccessor productsAccessor;

        public ProductsManager()
        {
            productsAccessor = new ProductsAccessor();
        }

        public ProductsManager(IProductsAccessor productsAccessor)
        {
            this.productsAccessor = productsAccessor;
        }

        public bool addProduct(Product product)
        {
            bool result = false;
            try
            {
                result = productsAccessor.inserProduct(product);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool deleteProduct(int id)
        {
            bool result = false;
            try
            {
                result = productsAccessor.deleteProductById(id);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = productsAccessor.selectAllProducts();
            }
            catch (Exception)
            {

                throw;
            }
            return products;
        }

        public Product getProductsById(int? id)
        {
            Product product = new Product();
            try
            {
                product = productsAccessor.selectProductById(id);
            }
            catch (Exception)
            {

                throw;
            }
            return product;
        }

        public int updateProduct(Product product)
        {
            int result = 0;
            try
            {
                result = productsAccessor.updateProduct(product);
            }
            catch (Exception)
            {

                throw;
            }
            return result;

        }
    }
}
