using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ChapterFiveAssignment
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
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearFees();
        }

        private void ClearFees()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void ClearOther()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void ClearMisc()
        {
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void ClearFlushes()
        {
            checkBox6.Checked = false;
            checkBox7.Checked = false;
        }

        private void ClearOilLube()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (chargesListBox.Items.Count == 0)
            {
                MessageBox.Show("Please load a service charges file.");
            }
            else
            {
                int OilLube = OilLubeCharges();
                int Flush = FlushCharges();
                int Misc = MiscCharges();
                int Other = OtherCharges();
                double Tax = TaxCharges();
                double Total = TotalCharges(Tax, OilLube, Flush, Misc);

                int service;
                try
                {
                    service = System.Convert.ToInt32(textBox2.Text);
                }
                catch (Exception)
                {
                    service = 0;
                }

                double parts;
                try
                {
                    parts = double.Parse(textBox1.Text);
                }
                catch (Exception)
                {
                    parts = 0;
                }

                textBox3.Text = "$" + (OilLube + Flush + Misc + service).ToString();
                textBox4.Text = "$" + parts.ToString();
                textBox5.Text = "$" + Tax.ToString();
                textBox6.Text = "$" + Total.ToString();
            }
        }

        private double TotalCharges(double Tax, int OilLube, int Flush, int Misc)
        {
            int service;
            try
            {
                service = System.Convert.ToInt32(textBox2.Text);
            }
            catch (Exception)
            {
                service = 0;
            }
            int ServiceAndLabor = OilLube + Flush + Misc + service;
            double Parts;
            try
            {
                Parts = double.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                Parts = 0;
            }
            double total = ServiceAndLabor + Parts + Tax;
            return total;
        }

        private double TaxCharges()
        {
            double price = 0;
            double parts;
            try
            {
                parts = double.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                 parts = 0;
            }
            price = price + (parts * 0.06);
            
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }

        private int OtherCharges()
        {
            try
            {
                return System.Convert.ToInt32(textBox1.Text) + System.Convert.ToInt32(textBox2.Text);
            }
            catch (Exception)
            {
                return 0;
            }
            }

        private int MiscCharges()
        {
            int price = 0;
            if (checkBox3.Checked == true)
            {
                price = price + 15;
            }
            if (checkBox4.Checked == true)
            {
                price = price + 100;
            }
            if (checkBox5.Checked == true)
            {
                price = price + 20;
            }
            return price;
        }

        private int FlushCharges()
        {
            int price = 0;
            if (checkBox6.Checked == true)
            {
                price = price + 30;
            }
            if (checkBox7.Checked == true)
            {
                price = price + 80;
            }
            return price;
        }

        private int OilLubeCharges()
        {
            int price = 0;
            if (checkBox1.Checked == true){
                    price = price + 26;
                }
            if (checkBox2.Checked == true)
            {
                price = price + 18;
            }
            return price;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filename;
            GetFileName(out filename);
            GetCharges(filename);
        }

        private void GetFileName(out string selectedFile)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                selectedFile = openFile.FileName;
            }
            else
            {
                selectedFile = "";
            }
        }

        private void GetCharges(String filename)
            {
                try
                {
                    string countryName;
                    StreamReader inputFile;
                    inputFile = File.OpenText(filename);
                    chargesListBox.Items.Clear();
                    while (!inputFile.EndOfStream)
                    {
                        countryName = inputFile.ReadLine();
                       chargesListBox.Items.Add(countryName);
                    }
                    inputFile.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
}
