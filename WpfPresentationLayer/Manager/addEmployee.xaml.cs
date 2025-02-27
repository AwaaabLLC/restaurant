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
using ILogicLayer;
using LogicLayer;

namespace WpfPresentationLayer.Manager
{
    /// <summary>
    /// Interaction logic for addEmployee.xaml
    /// </summary>
    public partial class addEmployee : Page
    {
        private IEmployeesManager employeesManager;
        public addEmployee()
        {
            InitializeComponent();
            employeesManager = new EmployeesManager();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (isFormValid())
            {
                Employee employee = new Employee();
                employee.FirstName = txtFirstname.Text;
                employee.LastName = txtLastname.Text;
                employee.CellPhone = txtCellPhone.Text;
                employee.EmailAddress = txtEmail.Text;
                try
                {
                    if (employeesManager.addNewEmployee(employee))
                    {
                        resetForm();
                    }
                    else 
                    {
                        lblSpan.Content = "add new emplyee did not done correctly!";
                    }
                }
                catch (Exception ex)
                {

                    lblSpan.Content = ex.Message;
                }

            }
        }

        private void resetForm()
        {
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty; 
            txtCellPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            lblSpan.Content = string.Empty;
        }

        private bool isFormValid()
        {
            if (txtFirstname.Text.Length == 0) 
            {
                lblSpan.Content = "Firt name require";
                return false;
            }
            if (txtLastname.Text.Length == 0)
            {
                lblSpan.Content = "Last name require";
                return false;
            }
            if (txtCellPhone.Text.Length == 0)
            {
                lblSpan.Content = "Cell Phone require";
                return false;
            }
            if (txtEmail.Text.Length == 0)
            {
                lblSpan.Content = "Email require";
                return false;
            }
            lblSpan.Content = string.Empty;
            return true;
        }
    }
}
