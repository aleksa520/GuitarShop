using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtUsername.SendToBack();
            txtPassword.SendToBack();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                return;
            }
            if (Communication.Instance.Connect())
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                Customer cust = Communication.Instance.CustomerLogin(username, password);

                if (cust != null)
                {
                    Hide();
                    Session.Instance.Customer = cust;
                    FrmMain frmMain = new FrmMain(FormType.CustomerForm);
                    frmMain.ShowDialog();
                    Close();
                    return;
                }

                Employee emp = Communication.Instance.EmployeeLogin(username, password);

                if (emp != null)
                {
                    Hide();
                    Session.Instance.Employee = emp;
                    FrmMain frmMain = new FrmMain(FormType.EmployeeForm);
                    frmMain.ShowDialog();
                    Close();
                    return;
                }

                Communication.Instance.ShowMessageBox("Username Or Password Is Incorrect!");
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                Communication.Instance.ShowMessageBox("Cannot Connect To The Server!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            FrmRegister frmRegister = new FrmRegister();
            frmRegister.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }
    }
}