using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapterThreeAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = (int.Parse(textBox1.Text)*15).ToString();
            textBox5.Text = (int.Parse(textBox2.Text)*12).ToString();
            textBox6.Text = (int.Parse(textBox3.Text)*9).ToString();
            int x = int.Parse(textBox4.Text) + int.Parse(textBox5.Text) + int.Parse(textBox6.Text);
            textBox7.Text = x.ToString();
        }
    }
}
