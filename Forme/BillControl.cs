using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Forme
{
    public partial class BillControl : UserControl
    {
        public static BindingList<Item> BillItems { get; set; }
        public Bill Bill { get; set; }
        public BillControl()
        {
            InitializeComponent();
            Bill = new Bill();
            BillItems = new BindingList<Item>();
            dgvBillItems.DataSource = BillItems;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if(BillItems.Count == 0)
            {
                Communication.Instance.ShowMessageBox("Your Bill is Empty!");
                return;
            }
            Bill.Items = BillItems.ToList();
            Bill.Customer = Session.Instance.Customer;
            if (Communication.Instance.AddBill(Bill))
            {
                Communication.Instance.ShowMessageBox("Bill Added!");
            }
        }
    }
}
