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
    public partial class AddGuitarControl : UserControl
    {
        public AddGuitarControl()
        {
            InitializeComponent();
            cmbArticleType.DataSource = Communication.Instance.GetArticleTypes();
            cmbManufacturer.DataSource = Communication.Instance.GetManufacturers();
        }

        private void AddGuitarControl_Load(object sender, EventArgs e)
        {

        }

        private void cmbArticleType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
