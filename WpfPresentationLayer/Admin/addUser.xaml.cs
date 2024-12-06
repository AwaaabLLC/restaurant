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
        private IUsersManager usersManager;
        private IEmployeesManager employeesManager;
        private List<User> users;
        private List<string> emails;
        public addUser()
        {
            InitializeComponent();
            usersManager = new UsersManager();
            employeesManager = new EmployeesManager();
            users = new List<User>();
            emails = new List<string>();
            updateDropDownLists();
        }

        private void updateDropDownLists()
        {
            List<Employee> employees = new List<Employee>();
            employees = employeesManager.getAllEmployees();
            foreach (Employee employee in employees)
            {
                emails.Add(employee.EmailAddress);
            }
            users = usersManager.getAllUsers();
            List<string> emailsWithoutUser = new List<string>();
            foreach (string email in emails) 
            {
                bool result = true;
                foreach (User user in users) 
                {
                    if (email.Equals(user.EmailAddress))
                    {
                        result = false;
                    }
                }
                if (result) emailsWithoutUser.Add(email);
            }
            ComboEmail.ItemsSource = emailsWithoutUser;
            lblSpan.Content = "there is " + emailsWithoutUser.Count + " employees without users";
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool addStatus = false;
            
            if (isFormValid())
            {
                User user = new User();
                user.EmailAddress = ComboEmail.SelectedItem.ToString();
                foreach (User item in users)
                {
                    if (item.EmailAddress.Equals(user.EmailAddress))
                    {
                        user.EmployeeId = item.EmployeeId;
                        break;
                    }
                }
                try
                {
                    addStatus = usersManager.addNewUser(user);
                }
                catch (Exception ex)
                {

                    lblSpan.Content = "Already have acount " + ex.Message;
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
            ComboEmail.SelectedIndex = 0;
        }
        private bool isFormValid()
        {
            if (ComboEmail.SelectedItem == null)
            {
                lblSpan.Content = "select email from dropdown lsit";
                return false;
            }
            lblSpan.Content = "";
            return true;
        }

        private void ComboEmail_DropDownClosed(object sender, EventArgs e)
        {
            string? email = null;
            if (ComboEmail.SelectedItem.ToString() != null)
            {
                email = ComboEmail.SelectedItem.ToString();
            }
            List<Employee> employees = new List<Employee>();
            employees = employeesManager.getAllEmployees();
            Employee employee = new Employee();
            foreach (Employee emp in employees)
            {
                if (emp.EmailAddress.Equals(email))
                {
                    txtEmployeeId.Text = emp.EmployeeId.ToString();
                    txtFirstName.Text = emp.FirstName.ToString();
                    txtLastName.Text = emp.LastName.ToString();
                    txtPhones.Text = emp.CellPhone;
                }
            }

        }
    }
}
