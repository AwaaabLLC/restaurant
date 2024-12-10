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
using DataObjectLayer;

namespace WpfPresentationLayer.Manager
{
    /// <summary>
    /// Interaction logic for allEmployees.xaml
    /// </summary>
    public partial class allEmployees : Page
    {
        private EmployeesManager employeesManager;
        public allEmployees()
        {
            InitializeComponent();
            employeesManager = new EmployeesManager();
            refreshDataGridsData();
        }

        private void refreshDataGridsData()
        {
            List<DataObjectLayer.Employee> employees = new List<DataObjectLayer.Employee>();
            employees = getEmployeesData();
            dgEmployees.ItemsSource = employees;
        }

        private List<DataObjectLayer.Employee> getEmployeesData()
        {
            try
            {
                return employeesManager.getAllEmployees();
            }
            catch (Exception ex)
            {

                lblSpan.Content = ex.Message;
            }
            return new List<DataObjectLayer.Employee>();
        }
    }
}
