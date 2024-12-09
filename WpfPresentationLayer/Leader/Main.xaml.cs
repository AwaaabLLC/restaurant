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

namespace WpfPresentationLayer.Leader
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

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            frmLeaderMain.Navigate(new System.Uri("./Leader/products.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnViewProducts_Click(object sender, RoutedEventArgs e)
        {
            frmLeaderMain.Navigate(new System.Uri("./Leader/viewAllProducts.xaml",UriKind.RelativeOrAbsolute));
        }
    }
}
