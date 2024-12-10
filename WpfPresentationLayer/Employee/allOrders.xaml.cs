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
using DataObjectLayer;
using ILogicLayer;
using LogicLayer;

namespace WpfPresentationLayer.Employee
{
    /// <summary>
    /// Interaction logic for allOrders.xaml
    /// </summary>
    public partial class allOrders : Page
    {
        private IOrdersManager ordersManager;
        public allOrders()
        {
            InitializeComponent();
            ordersManager = new OrdersManager();
            refreshDataGrid();
        }

        private void refreshDataGrid()
        {
            List<Order> orders = [];
            orders = getAllOrders();
            dgAllOrders.ItemsSource = orders;
        }

        private List<Order> getAllOrders()
        {
            List<Order> orders = [];
            try
            {
                orders = ordersManager.getAllOrders();
            }
            catch (Exception ex)
            {

                lblSpan.Content = ex.Message;
            }
            orders = ordersManager.getAllOrders();
            return orders;
        }
    }
}
