using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaDot
{
    public partial class Billing : Form
    {
        Functions Con;
        public Billing()
        {
            Con = new Functions();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonPriceSet_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.Show();
            this.Hide();
        }

        int Key = 0;
        int Price = 0;

        private void GetPrice(int Key)
        {
            string Pizza = "";
            if (Key == 1)
            {
                Pizza = "Small";
            }
            else if (Key == 2)
            {
                Pizza = "Medium";
            }
            else if (Key == 3)
            {
                Pizza = "Large";
            }
            else if (Key == 4)
            {
                Pizza = "Extra Large";
            }

            string Query = "select * from PizzaTable where Item = '{0}'";
            Query = string.Format(Query, Pizza);
            Price = Convert.ToInt32(Con.GetData(Query).Rows[0][1].ToString());

        }
        int n = 0;
        int GrdTotal;
        string Items;
        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            if (radioButtonSmall.Checked == true)
            {
                Key = 1;
                Items = "Small Pizza";
            }
            else if (radioButtonMedium.Checked == true)
            {
                Key = 2;
                Items = "Medium Pizza";
            }
            else if (radioButtonLarge.Checked == true)
            {
                Key = 3;
                Items = "Large Pizza";
            }
            else if (radioButtonExtraLarge.Checked == true)
            {
                Key = 4;
                Items = "Extra Large Pizza";
            }

            GetPrice(Key);

            int Qty = Convert.ToInt32(textBoxQuantity.Text);
            int total = Qty * Price;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dataGridViewBill);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = Items;
            newRow.Cells[2].Value = Price;
            newRow.Cells[3].Value = textBoxQuantity.Text;
            newRow.Cells[4].Value = total;
            dataGridViewBill.Rows.Add(newRow);
            n++;
            GrdTotal = GrdTotal + total;
            GrdTotaltbl.Text = "TK " + GrdTotal;

        }

        private void buttonPrintOrder_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        int prodid, prodprice, prodqty, tottal, pos = 70;

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("PIZZA ORDERING", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(60));
            foreach (DataGridViewRow row in dataGridViewBill.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column3"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);

                e.Graphics.DrawString("" + prodid, new Font(" Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font(" Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font(" Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(130, pos));
                e.Graphics.DrawString("" + prodqty, new Font(" Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font(" Century Gothic ", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));

                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total:  TK" + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("**********PIZZA*********", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            dataGridViewBill.Rows.Clear();
            dataGridViewBill.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;
        }
    }
}