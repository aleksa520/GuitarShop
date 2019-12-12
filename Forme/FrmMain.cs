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
    public enum FormType
    {
        CustomerForm,
        EmployeeForm
    }

    public partial class FrmMain : Form
    {
        public FrmMain(FormType formType)
        {
            InitializeComponent();
            if (Session.Instance.Employee != null)
            {
                lblName.Text = Session.Instance.Employee.ToString();
            }
            else if (Session.Instance.Customer != null)
            {
                lblName.Text = Session.Instance.Customer.ToString();
            }

            if(formType == FormType.CustomerForm)
            {
                btnBill.BringToFront();
            }
            else
            {
                btnAddGuitar.BringToFront();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button1.Height;
            slidePanel.Top = button1.Top;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnBill.Height;
            slidePanel.Top = btnBill.Top;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = lblName.Text;
            if (Session.Instance.Customer != null && Session.Instance.Customer.ToString() == name)
            {
                Session.Instance.Customer = null;
            }
            else
            {
                Session.Instance.Employee = null;
            }

            slidePanel.Height = button3.Height;
            slidePanel.Top = button3.Top;
            Hide();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            Close();       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            slidePanel.Height = button7.Height;
            slidePanel.Top = button7.Top;
        }

        private void btnAddGuitar_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnAddGuitar.Height;
            slidePanel.Top = btnAddGuitar.Top;
        }
    }
}
