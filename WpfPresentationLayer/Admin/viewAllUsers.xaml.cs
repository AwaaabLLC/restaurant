using DataObjectLayer;
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

namespace WpfPresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for viewAllEmployees.xaml
    /// </summary>
    public partial class viewAllEmployees : Page
    {
        private IUsersManager usersManager;
        private List<User> users;
        public viewAllEmployees()
        {
            InitializeComponent();
            usersManager = new UsersManager();
            users = new List<User>();
            updateDgViewAllUsers();

        }

        private void updateDgViewAllUsers()
        {
            try
            {
                users = usersManager.getAllUsers();
                dgViewAllUsers.ItemsSource = users;
            }
            catch (Exception ex)
            {
                lblSpan.Content = ex.Message;
                return;
            }
        }

        private void btnActiveDeactive_Click(object sender, RoutedEventArgs e)
        {
            User user;
            if (dgViewAllUsers.SelectedItem != null)
            {
                user = (User)dgViewAllUsers.SelectedItem;
            }
            else 
            {
                lblSpan.Content = "please select employee row from list";
                return;            
            }
            lblSpan.Content = string.Empty;
            try
            {
                user.Active = !user.Active;
                if (usersManager.deactiveActiveUser(user))
                {
                    updateDgViewAllUsers();
                }
                else
                {
                    lblSpan.Content = "active/ deactive process not done, please try again";
                    return;
                }
            }
            catch (Exception ex)
            {

                lblSpan.Content = ex.Message;
            }
        }
    }
}
