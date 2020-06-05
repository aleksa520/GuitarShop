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
    public partial class ViewBillsControl : UserControl
    {
        public BindingList<Bill> Bills { get; set; }
         
        public ViewBillsControl()
        {
            InitializeComponent();
            Bills = new BindingList<Bill>();
            Bills = new BindingList<Bill>(Communication.Instance.GetBills());
            dataGridView1.DataSource = Bills;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                Bill bill = (dataGridView1.SelectedRows[0].DataBoundItem as Bill);
                BillView billView = new BillView(bill);
                billView.ShowDialog();
            }
            catch
            {
                Communication.Instance.ShowMessageBox("Select Row To View Bill");
            }
        }
    }
}
