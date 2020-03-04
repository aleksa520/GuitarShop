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
            mainPanel.BringToFront();
            guitarStickerPanel.BringToFront();
        }

        private void btnGuitars_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnGuitars.Height;
            slidePanel.Top = btnGuitars.Top;
            viewGuitarsControl.BringToFront();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnBill.Height;
            slidePanel.Top = btnBill.Top;
            billControl.BringToFront();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
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

            slidePanel.Height = btnLogOut.Height;
            slidePanel.Top = btnLogOut.Top;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnHome.Height;
            slidePanel.Top = btnHome.Top;
            mainPanel.BringToFront();
            guitarStickerPanel.BringToFront();
        }

        private void btnAddGuitar_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btnAddGuitar.Height;
            slidePanel.Top = btnAddGuitar.Top;
            addGuitarControl.BringToFront();
        }

        private void btnViewGuitars_Click(object sender, EventArgs e)
        {
            //slidePanel.Height = btnGuitars.Height;
            //slidePanel.Top = btnGuitars.Top;
            viewBillsControl.BringToFront();
        }
    }
}
