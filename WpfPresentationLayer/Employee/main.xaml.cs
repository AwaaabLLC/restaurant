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
using System.Windows.Shapes;

namespace WpfPresentationLayer.Employee
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee.Navigate(new System.Uri("./Employee/addOrder.xaml",UriKind.RelativeOrAbsolute));
        }

        private void btnViewOrders_Click(object sender, RoutedEventArgs e)
        {
            frmEmployee.Navigate(new System.Uri("./Employee/allOrders.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
