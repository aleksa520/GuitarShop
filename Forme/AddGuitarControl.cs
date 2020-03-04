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

            cmbArticleType.SelectedItem = null;
            cmbArticleType.Text = "--select article type--";

            cmbManufacturer.SelectedItem = null;
            cmbManufacturer.Text = "--select manufacturer--";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Manufacturer manufacturer = (Manufacturer)cmbManufacturer.SelectedItem;
            ArticleType articleType = (ArticleType)cmbArticleType.SelectedItem;
            try
            {
                Article article = new Article()
                {
                    Name = textBox1.Text,
                    Price = Double.Parse(textBox2.Text),
                    Manufacturer = manufacturer,
                    ArticleType = articleType
                };
                if (Communication.Instance.AddArticle(article))
                {
                    ViewGuitarsControl.Articles.Add(article);
                    Communication.Instance.ShowMessageBox($"{textBox1.Text} Added");
                }
                else
                {
                    Communication.Instance.ShowMessageBox("Error in Adding Article");
                }
            }
            catch (Exception)
            {
                Communication.Instance.ShowMessageBox("Error in Adding Article");
            }
        }
    }
}
