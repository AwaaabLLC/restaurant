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
using Microsoft.Win32;
using ILogicLayer;
using LogicLayer;

namespace WpfPresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for addUser.xaml
    /// </summary>
    public partial class addUser : Page
    {
        private IUsersManager _usersManager;
        public addUser()
        {
            InitializeComponent();
            _usersManager = new UserManager();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool addStatus = false;
            
            if (isFormValid())
            {
                User user = new User();
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.EmailAddress = txtEmail.Text;
                user.UserName = txtEmail.Text;
                user.CellPhone = txtCellPhone.Text;
                user.Password = txtPassword.Password;
                try
                {
                    addStatus = _usersManager.addNewUser(user);
                }
                catch (Exception ex)
                {

                    lblSpan.Content = ex.ToString();
                    return;
                }
                if (addStatus)
                {
                    lblSpan.Content = lblSpan.Content + " add status is true";
                    clearForm();
                }
                else
                {
                    lblSpan.Content = "add status is false!";
                }
                
            }
            
        }
        private void clearForm()
        {
            txtFirstName.Text = string.Empty;  
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCellPhone.Text = string.Empty;
            txtPassword.Password = string.Empty;
            txtConfirmPassword.Password = string.Empty;
        }
        private bool isFormValid()
        {
            if (txtFirstName.Text.Length == 0) { lblSpan.Content = "First name require"; txtFirstName.Focus(); return false; }
            if (txtLastName.Text.Length == 0) { lblSpan.Content = "Last name require"; txtLastName.Focus(); return false; }
            if (txtEmail.Text.Length == 0) { lblSpan.Content = "Email require"; txtEmail.Focus(); return false; }
            if (txtCellPhone.Text.Length == 0) { lblSpan.Content = "Cell phone require"; txtCellPhone.Focus(); return false; }
            if (txtPassword.Password.Length == 0) { lblSpan.Content = "Password require"; txtPassword.Focus(); return false; }
            if (txtConfirmPassword.Password.Length == 0) { lblSpan.Content = "Confirm password require"; txtConfirmPassword.Focus(); return false; }
            if (!txtConfirmPassword.Password.Equals(txtPassword.Password)) { lblSpan.Content = "Confirm password must match password"; txtConfirmPassword.Focus(); return false; }
            lblSpan.Content = "";
            return true;
        }
    }
}
