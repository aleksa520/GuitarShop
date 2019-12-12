using Domain;
using Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "")
            {
                return;
            }
            if (Communication.Instance.Connect())
            {
                if (!Validation())
                {
                    Communication.Instance.ShowMessageBox("Username Allready Exists!");
                    return;
                }

                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                Customer cust = Communication.Instance.CustomerRegistration(firstName, lastName, username, password);     
                if(cust != null)
                {
                    Hide();
                    Communication.Instance.ShowMessageBox("You Have Created an Account!");
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                    Close();
                    return;
                }
                Communication.Instance.ShowMessageBox("Username Allready Exists!");
            }
            else
            {
                Communication.Instance.ShowMessageBox("Cannot Connect To The Server!");

            }
        }

        public bool Validation()
        {
            string username = txtUsername.Text;

            return Communication.Instance.Validation(username);
     
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            Close();
        }
    }
}
