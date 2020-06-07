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
    public partial class ViewGuitarsControl : UserControl
    {
        public static BindingList<Article> Articles { get; set; }
        public ViewGuitarsControl()
        {
            InitializeComponent();
            Articles = new BindingList<Article>(Communication.Instance.GetArticles());
            dataGridView1.DataSource = Articles;
            if (Session.Instance.Employee != null)
            {
                btnAddToBill.Hide();
            }
            else
            {
                btnDelete.Hide();
                btnEdit.Hide();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Article article = null;
            string articleName = "";
            try
            {
                article = (dataGridView1.SelectedRows[0].DataBoundItem as Article);
            }
            catch
            {
                Communication.Instance.ShowMessageBox("Select Row To Delete Article!");
                return;
            }

            try
            {
                articleName = article.Name;
                Communication.Instance.DeleteArticle(article);
                Articles.Remove(article);
                Communication.Instance.ShowMessageBox($"{articleName} Has Been Deleted!");
            }
            catch (Exception)
            {
                Communication.Instance.ShowMessageBox("Can't Delete This Article!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Article article = (dataGridView1.SelectedRows[0].DataBoundItem as Article);
                FrmEditArticle frmEdit = new FrmEditArticle(article);
                frmEdit.ShowDialog();
            }
            catch
            {
                Communication.Instance.ShowMessageBox("Select Row To Edit Article");
            }
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            try
            {
                Article article = (dataGridView1.SelectedRows[0].DataBoundItem as Article);
                Item item = new Item()
                {
                    Article = article,
                    Count = 1
                };

                for (int i = 0; i < BillControl.BillItems.Count; i++)
                {
                    if (BillControl.BillItems[i].Article == article)
                    {
                        BillControl.BillItems[i].Count++;
                        Communication.Instance.ShowMessageBox($"{article.Name} Added To The Bill");
                        return;
                    }
                }

                BillControl.BillItems.Add(item);
                Communication.Instance.ShowMessageBox($"{article.Name} Added To The Bill");
            }
            catch (Exception)
            {
                Communication.Instance.ShowMessageBox($"Select Row To Add To The Bill");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingList<Article> filteredArticles;
            filteredArticles = new BindingList<Article>(Communication.Instance.SearchArticles(txtCriteria.Text));
            Articles = filteredArticles;
            dataGridView1.DataSource = Articles;
        }
    }
}
