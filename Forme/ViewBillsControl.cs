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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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

        private void btnPDF_Click(object sender, EventArgs e)
        {

            DateTime from = dateFrom.Value;
            DateTime to = dateTo.Value;

            using (SaveFileDialog std = new SaveFileDialog(){ Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if(std.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(std.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph("==========================================="));
                        doc.Add(new iTextSharp.text.Paragraph("===================Bills====================="));
                        doc.Add(new iTextSharp.text.Paragraph("==========================================="));
                        string header = "";
                        header += string.Format("{0,-10}", "Value");
                        header += string.Format("{0,-16}", "Employee");
                        header += string.Format("{0,30}", "Date");
                        doc.Add(new iTextSharp.text.Paragraph(header));
                        doc.Add(new iTextSharp.text.Paragraph("==========================================="));
                        double totalSum = 0;

                        string s = "";

                        foreach(var b in Bills)
                        {
                            if(b.Date > from && b.Date < to)
                            {
                                s += string.Format("{0,-10}", b.Value.ToString());
                                s += string.Format("{0,-16}", b.Employee.ToString());
                                s += string.Format("{0,30}", b.Date.ToString());
                                s += "\n";
                                totalSum += b.TotalValue;
                            }                       
                        }

                        doc.Add(new iTextSharp.text.Paragraph(s));

                        doc.Add(new iTextSharp.text.Paragraph("==========================================="));
                        doc.Add(new iTextSharp.text.Paragraph("Total Value: " + totalSum));
                        Communication.Instance.ShowMessageBox("PDF is Saved!");

                    }
                    catch (Exception ex)
                    {
                        Communication.Instance.ShowMessageBox("Error in Saving a PDF");
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }
    }
}
