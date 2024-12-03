using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _flag;
        public MainWindow()
        {
            InitializeComponent();
            _flag = true;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_flag)
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;
                if (isVerified(username,password) && isAutherize(username, password))
                {
                    _flag = !_flag;
                    btnLogin.Content = "Logout";
                    string role = getRole(username);
                    if (role.Equals("Admin"))
                    {
                        Admin.Main main = new Admin.Main();
                        main.Show();
                        this.Close();
                    }
                }
                else return; 
            }
            else {
                lblLoginSpan.Content = "submit login unpressed";
                _flag = !_flag;
                btnLogin.Content = "Login";
            }
            
        }

        private string getRole(string username)
        {
            if (username.Equals("Admin"))
            {
                return "Admin";
            }

            return "";
        }

        private bool isVerified(string username, string password)
        {
            if (username.Length == 0)
            {
                lblLoginSpan.Content = "username is require";
                return false;
            }
            if (password.Length == 0)
            {
                lblLoginSpan.Content = "password is require";
                return false;
            }
            return true;
        }

        private bool isAutherize(string username, string password)
        {
            if (username.Equals("Admin") && password.Equals("Admin")) return true;
            lblLoginSpan.Content = "username and password is not match!";
            return false;
        }
    }
}