using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class frmLogin : Form
    {
        private UserManager userManager = new UserManager();
        private int userId;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userId = 0;
            if (txtUserName.Text == "")
            {
                lblError.Text = "Enter your User Name";
                txtUserName.Clear();
                txtUserName.Focus();
                return;
            }
            if (txtUserName.TextLength < 3)
            {
                lblError.Text = "Invalid UserName";
                txtUserName.Clear();
                txtUserName.Focus();
                txtPassword.Clear();
                return;

            }
            if (txtPassword.TextLength < 3)
            {
                lblError.Text = "Invalid Password";
                txtPassword.Clear();
                txtPassword.Focus();
                txtUserName.Clear();
                return;

            }
            if (txtPassword.TextLength == 0)

            {
                lblError.Text = "Enter your Password";
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }
            userId = userManager.ValidateUser(txtUserName.Text, txtPassword.Text);
            if (userId != 0)
            {
                this.Hide();
                var oreder = new frmOrder(userId);
                oreder.ShowDialog();
                
            }
            else
            {
                lblError.Text = "UserName Or Password is incorect ";

            }
        }

       
    }
}
