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
        private Thread thread;

        public FrmLogin()
        {
            InitializeComponent();
            txtUsername.SendToBack();
            txtPassword.SendToBack();
            thread = new Thread(check);
            thread.IsBackground = true;
            thread.Start();
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
                    thread.Interrupt();
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
                    thread.Interrupt();
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
            thread.Interrupt();
            Close();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            //txtUsername.BringToFront();
        }

        private void check()
        {
            try
            {
                Thread.Sleep(2000);
                while (true)
                {

                    //this.Invoke(new Action(() =>
                    //{
                    //    if (txtUsername.Text == "")
                    //        txtUsername.SendToBack();
                    //}));

                    this.Invoke(new Action(() =>
                    {
                        if (txtPassword.Text == "")
                            txtPassword.SendToBack();
                    }));

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine(">>> " + e.Message);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            txtPassword.BringToFront();
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
    }
}
