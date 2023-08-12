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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if(textUserName.Text == "" || textPassword.Text == "")
            {
                MessageBox.Show("Missing Informations.");
            }
            else if(textUserName.Text == "Karib" && textPassword.Text == "1111041")
            {
                Billing bi = new Billing();
                bi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Data.");
            }
        }
    }
}
