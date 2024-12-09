using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLayer;
using ILogicLayer;
using DataObjectLayer;

namespace WpfPresentationLayer.Leader
{
    /// <summary>
    /// Interaction logic for viewAllProducts.xaml
    /// </summary>
    public partial class viewAllProducts : Page
    {
        private IProductsManager productsManager;
        public viewAllProducts()
        {
            InitializeComponent();
            productsManager = new ProductsManager();
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = productsManager.getAllProducts();
                dgViewAllProducts.ItemsSource = products;
            }
            catch (Exception ex)
            {
                lblSpan.Content = ex.Message;
            }
           
        }
    }
}
