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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        private IProductsManager productsManager;
        public Products()
        {
            InitializeComponent();
            productsManager = new ProductsManager();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (isFormValid())
            {
                Product product = new Product();
                product.UPC  = txtUPC.Text;
                product.Name = txtName.Text;
                product.Price = txtPrice.Text;
                product.QTY = txtQty.Text;
                try
                {
                    bool result = productsManager.addProduct(product);
                    if (result)
                    {
                        clearForm();
                    }
                    else 
                    {
                        lblSpan.Content = "add new product is not done!";
                    }
                }
                catch (Exception ex)
                {
                    lblSpan.Content = ex.Message;
                }
            }
        }

        private void clearForm()
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtUPC.Text = string.Empty;
            lblSpan.Content = string.Empty;
        }

        private bool isFormValid()
        {
            if (txtUPC.Text.Length == 0)
            {
                lblSpan.Content = "UPC is require";
                return false;
            }
            if (txtQty.Text.Length == 0) 
            {
                lblSpan.Content = "QTY is require";
                return false;
            }
            if (txtName.Text.Length == 0) 
            {
                lblSpan.Content = "Name is require";
                return false;
            }
            if (txtPrice.Text.Length == 0)
            {
                lblSpan.Content = "Price is require";
                return false ;
            }
            lblSpan.Content = string.Empty;
            return true;
        }
    }
}
