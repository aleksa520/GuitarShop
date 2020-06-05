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
        public List<Employee> MyEployees { get; set; }
        public Bill Bill { get; set; }
        public BillControl()
        {
            InitializeComponent();
            Bill = new Bill();
            BillItems = new BindingList<Item>();
            dgvBillItems.DataSource = BillItems;
            MyEployees = Communication.Instance.GetEmployees();
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
            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Friday ||
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                Bill.Employee = MyEployees[0];
            }
            else if(MyEployees.Count > 1)
            {
                Bill.Employee = MyEployees[1];
            }
            else
            {
                Bill.Employee = MyEployees[0];
            }
          
            if (Communication.Instance.AddBill(Bill))
            {
                string total = BillItems.Sum(x => x.Value).ToString();
                Communication.Instance.ShowMessageBox($"Thank You For Your Purchase!" +
                    $"\nYour Total Amount Is {total} $");
                BillItems.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = (dgvBillItems.SelectedRows[0].DataBoundItem as Item);
                BillItems.Remove(item);
            }
            catch
            {
                Communication.Instance.ShowMessageBox("Select Row To Delete Article");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
