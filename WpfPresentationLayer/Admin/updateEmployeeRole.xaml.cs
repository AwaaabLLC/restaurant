using DataObjectLayer;
using ILogicLayer;
using LogicLayer;
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

namespace WpfPresentationLayer.Admin
{
    /// <summary>
    /// Interaction logic for updateEmployeeRole.xaml
    /// </summary>
    public partial class updateRole : Page
    {
        private List<Employee> employees;
        private IEmployeesManager employeesManager;
        private IUsersManager usersManager;
        private List<string> emails = new List<string>();
        private List<string> roles = new List<string>();
        public updateRole()
        {
            InitializeComponent();
            employeesManager = new EmployeesManager();
            usersManager = new UsersManager();
            employees = new List<Employee>();
            getAllEmployees();
            getAllRoles();
            fillCombo();
        }

        private void getAllRoles()
        {
            try
            {
                roles = usersManager.getAllRoles();
            }
            catch (Exception ex)
            {

                lblSpan.Content = ex.Message;
            }
        }

        private void fillCombo()
        {
            emails = new List<string>();
            foreach (Employee e in employees) 
            {
                emails.Add(e.EmailAddress);
            }
            comboEmail.ItemsSource = emails;
            comboEmail.SelectedIndex = 0;
            comboRole.ItemsSource = roles;
            comboRole.SelectedIndex = 0;

        }

        private void getAllEmployees()
        {
            try
            {
                employees = employeesManager.getAllEmployees();
            }
            catch (Exception ex)
            {
                lblSpan.Content = ex.Message;
            }
        }

        private void comboEmail_DropDownClosed(object sender, EventArgs er)
        {
            Employee employee= new Employee();
            if (comboEmail.SelectedIndex >= 0)
            {
                foreach (Employee e in employees)
                {
                    if (e.EmailAddress.Equals(comboEmail.SelectedItem))
                    {
                        txtFirstName.Text = e.FirstName;
                        txtLastName.Text = e.LastName;
                        txtCellPhone.Text = e.CellPhone;
                        txtEmoloyeeId.Text = e.EmployeeId.ToString();
                        break;
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool status = usersManager.updateEmployeeRole(Convert.ToInt32(txtEmoloyeeId.Text), comboRole.SelectedItem.ToString());
                if (status) 
                {
                    lblSpan.Content = "update role done";
                    clearForm();
                }
            }
            catch (Exception ex)
            {
                lblSpan.Content = ex.Message;

            }
        }

        private void clearForm()
        {
           comboEmail.SelectedIndex = 0;
            comboRole.SelectedIndex = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtCellPhone.Text = string.Empty;
            txtEmoloyeeId.Text = string.Empty;
        }
    }
}
