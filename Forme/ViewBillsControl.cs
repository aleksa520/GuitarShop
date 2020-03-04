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
            Bills = new BindingList<Bill>(Communication.Instance.GetBills());
            dataGridView1.DataSource = Bills;
        }
    }
}
