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
using System.Reflection.Metadata.Ecma335;


namespace WpfPresentationLayer.Employee
{
    /// <summary>
    /// Interaction logic for addOrder.xaml
    /// </summary>
    public partial class addOrder : Page
    {
        private IProductsManager productsManager;
        private IOrdersManager ordersManager;
        public addOrder()
        {
            InitializeComponent();
            productsManager = new ProductsManager();
            ordersManager = new OrdersManager();
            refreshComboBox();
        }

        private void refreshComboBox()
        {
            List<Product> products = getAllProducts();
            List<string> productsNames = new List<string>();
            foreach (Product product in products) 
            { 
                productsNames.Add(product.Name);
            }
            comboProductName.ItemsSource = productsNames.ToArray();
            comboProductName.SelectedIndex = 0;
            List<int> tablesNumbers = new List<int>();
            for (int i = 1; i < 11; i++)
            {
                tablesNumbers.Add(i);
            }
            comboTableNumber.ItemsSource = tablesNumbers.ToArray();
            comboTableNumber.SelectedIndex = 0;
        }

        private List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                products = productsManager.getAllProducts();
            }
            catch (Exception ex)
            {
                lblSpan.Content = ex.Message;
            }
            return products;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (isFromValid())
            {
                bool result = false;
                Order order = new Order();
                order.ProductName = comboProductName.SelectedItem.ToString();
                order.CustomerName = txtCustomerName.Text.ToString();
                try
                {
                    order.TableNumber = Convert.ToInt32(comboTableNumber.SelectedItem);
                    result = ordersManager.addOrder(order);
                }
                catch (Exception ex)
                {
                    lblSpan.Content = ex.Message;
                }
                if (result)
                {
                    clearForm();
                }
                else 
                {
                    lblSpan.Content = "Order did not create correctly!";
                }    
            }
        }

        private void clearForm()
        {
            comboProductName.SelectedIndex = 0;
            comboTableNumber.SelectedIndex= 0;
            txtCustomerName.Text = string.Empty;
        }

        private bool isFromValid()
        {
            if (comboProductName.SelectedItem == null)
            {
                lblSpan.Content = "Product Name is require";
                return false;
            }
            if (comboTableNumber.SelectedItem == null) 
            {
                lblSpan.Content = "table Name is require";
                return false;
            }
            if (txtCustomerName.Text.Length == 0)
            {
                lblSpan.Content = "Customer name is require";
                return false;
            }
            lblSpan.Content = string.Empty;
            return true;
        }
    }
}
