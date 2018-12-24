using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreferredCustomerApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String address = textBox2.Text;
            String phone = textBox3.Text;
            Boolean mailing = false;
            if (radioButton1.Checked == true)
            {
                mailing = true;
            }
            if (radioButton1.Checked == false)
            {
                mailing = false;
            }
            double purchased = Convert.ToDouble(textBox4.Text);
            PreferredCustomer c = new PreferredCustomer(name, address, phone, mailing, purchased);

            string msg = "Full Name: " + c.name + "\nAddress: " + c.address + "\nPhone Number: " + c.phone + "\nPurchased Amount: $" + c.total + "\nFuture Discount Level: " + c.discount().ToString() + ".00%";
            MessageBox.Show(msg);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
