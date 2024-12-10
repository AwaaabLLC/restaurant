using ILogicLayer;
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
using LogicLayer;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _flag;
        private IUsersManager usersManager;
        public MainWindow()
        {
            InitializeComponent();
            usersManager = new UsersManager();
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
                    if (role.Equals("Manager")) 
                    { 
                        Manager.Main main = new Manager.Main();
                        main.Show();
                        this.Close();                    
                    }
                    if (role.Equals("leader"))
                    {
                        Leader.Main main = new Leader.Main();
                        main.Show();
                        this.Close();
                    }
                    if (role.Equals("Employee"))
                    {
                        Employee.Main main = new Employee.Main();
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
            string role = string.Empty;
            try
            {
                role = usersManager.getEmployeeRole(username);
            }
            catch (Exception ex)
            {

                lblLoginSpan.Content = ex.Message;
            }
            return role;
            
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
            if (usersManager.isAutherize(username, password)) return true;
            lblLoginSpan.Content = "username and password is not match!";
            return false;
        }
    }
}