using Azure.Core;
using DataObjectLayer;
using FakeDataAccessLayer;
using IDataAcessLayer;
using ILogicLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLogicLayer
{
    public class ProductsManagerTest
    {
        private static IProductsAccessor productsAccessor = new FakeDataAccessLayer.ProductsAccessor();
        private IProductsManager productsManager = new ProductsManager(productsAccessor);
        [Fact]
        public void TestAddProduct() 
        {
            Product product = new();
            product.Name = "Test";
            product.UPC = "123456789-6";
            product.QTY = "100";
            product.Price = "100";
            Assert.True(productsManager.addProduct(product));
        }
        [Fact]
        public void TestSelectAllProducts()
        {
            Assert.Equal(6,productsManager.getAllProducts().Count());
        }
    }
}
