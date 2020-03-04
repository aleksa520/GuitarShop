using Domain;
using Storage;
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
    public partial class FrmEditArticle : Form
    {
        public Article Article { get; set; }
        public FrmEditArticle(Article article)
        {
            InitializeComponent();
            Article = article;
            cmbArticleType.DataSource = Communication.Instance.GetArticleTypes();
            cmbManufacturer.DataSource = Communication.Instance.GetManufacturers();
            txtName.Text = Article.Name;
            txtPrice.Text = Article.Price.ToString();

            cmbArticleType.SelectedItem = null;
            cmbArticleType.Text = "--select article type--";

            cmbManufacturer.SelectedItem = null;
            cmbManufacturer.Text = "--select manufacturer--";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Article.Name = txtName.Text;
                Article.Price = Double.Parse(txtPrice.Text);
                Article.Manufacturer = (Manufacturer)cmbManufacturer.SelectedItem;
                Article.ArticleType = (ArticleType)cmbArticleType.SelectedItem;
                if (Communication.Instance.UpdateArticle(Article))
                {
                    for (int i = 0; i < ViewGuitarsControl.Articles.Count; i++)
                    {
                        if (Article.Id == ViewGuitarsControl.Articles[i].Id)
                        {
                            ViewGuitarsControl.Articles[i] = Article;
                            break;
                        }
                    }

                    Hide();
                    Close();
                }
                else
                {
                    Communication.Instance.ShowMessageBox("Article Wasn't Updated");
                }                           
            }
            catch (Exception)
            {
                Communication.Instance.ShowMessageBox("Insert Data Properly");
            }           
        }
    }
}
