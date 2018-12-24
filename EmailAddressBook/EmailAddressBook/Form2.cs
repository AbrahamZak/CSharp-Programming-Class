using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailAddressBook
{
    public partial class Form2 : Form
    {
        public Form2(String name, String email, String phone)
        {
            InitializeComponent();
            label1.Text = "Name: " + name;
            label2.Text = "Email: " + email;
            label3.Text = "Phone number: " + phone;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 m = new Form1();
            m.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
