using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaDot
{
    public partial class Settings : Form
    {
        Functions Con;
        public Settings()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            Billing bi = new Billing();
            bi.Show();
            this.Hide();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string Key;
            try
            {
                int Pr = Convert.ToInt32(textEnterPrice.Text);
                if (comboBoxSelectPizza.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a PIZZA!!!");
                }
                else if(comboBoxSelectPizza.SelectedIndex == 0)
                {
                    Key = "Extra Large";
                    string Query = "Update PizzaTable set Price = {0} where Item = '{1}'";
                    Query = string.Format(Query, Pr, Key);
                    Con.setData(Query);
                    MessageBox.Show("Price Update.");
                }
                else if(comboBoxSelectPizza.SelectedIndex == 1)
                {
                    Key = "Large";
                    string Query = "Update PizzaTable set Price = {0} where Item = '{1}'";
                    Query = string.Format(Query, Pr, Key);
                    Con.setData(Query);
                    MessageBox.Show("Price Update.");
                }
                else if (comboBoxSelectPizza.SelectedIndex == 2)
                {
                    Key = "Medium";
                    string Query = "Update PizzaTable set Price = {0} where Item = '{1}'";
                    Query = string.Format(Query, Pr, Key);
                    Con.setData(Query);
                    MessageBox.Show("Price Update.");
                }
                else if (comboBoxSelectPizza.SelectedIndex == 3)
                {
                    Key = "Small";
                    string Query = "Update PizzaTable set Price = {0} where Item = '{1}'";
                    Query = string.Format(Query, Pr, Key);
                    Con.setData(Query);
                    MessageBox.Show("Price Update.");
                }
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
