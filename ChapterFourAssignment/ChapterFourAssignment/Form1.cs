using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapterFourAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int days = 0;
            int lodgingCost = 0;
            int registationCost = 0;

            switch (listBox1.SelectedIndex)
            {
                case 0:
                    registationCost = 1000;
                    days = 3;
                    break;
                case 1:
                    registationCost = 800;
                    days = 3;
                    break;
                case 2:
                    registationCost = 1500;
                    days = 3;
                    break;
                case 3:
                    registationCost = 1300;
                    days = 5;
                    break;
                case 4:
                    registationCost = 500;
                    days = 1;
                    break;
                case -1:
                    break;
            }

            switch (listBox2.SelectedIndex)
            {
                case 0:
                    lodgingCost = (150 * days);
                    break;
                case 1:
                    lodgingCost = (225 * days);
                    break;
                case 2:
                    lodgingCost = (175 * days);
                    break;
                case 3:
                    lodgingCost = (300 * days);
                    break;
                case 4:
                    lodgingCost = (175 * days);
                    break;
                case 5:
                    lodgingCost = (150 * days);
                    break;
                case -1:
                    break;
            }

            textBox1.Text = registationCost.ToString();
            textBox2.Text = lodgingCost.ToString();
            textBox3.Text = (registationCost + lodgingCost).ToString();
            label6.Text = ("For " + days + " day(s)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            label6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
