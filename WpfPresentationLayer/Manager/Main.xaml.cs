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

namespace WpfPresentationLayer.Manager
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

        private void btnViewAllEmployees_Click(object sender, RoutedEventArgs e)
        {
            frmManagerMain.Navigate(new System.Uri("./Manager/allEmployees.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            frmManagerMain.Navigate(new System.Uri("./Manager/addEmployee.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
