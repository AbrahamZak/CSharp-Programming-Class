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

namespace DrinkVendingMachineSimulator
{
    public partial class Form1 : Form
    {
        public struct Drink
        {
            public String name;
            public double cost;
            public int quantity;
        }
        //Array for our drinks struct
        Drink[] drinks = new Drink[5];
        //Total drinks purchased
        double total = 0.00;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Import the file and load drink info
        private void button2_Click(object sender, EventArgs e)
        {
            string filename;
            GetFileName(out filename);
            GetDrinkInfo(filename);
        }

        //Method to get the file name from the openfile dialog
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

        //Method to get name, cost, and quantity for each drink from datafile, then populates the applicaton with data
        private void GetDrinkInfo(String filename)
        {
            try
            {
               //Read the file
                string drink;
                StreamReader inputFile;
                inputFile = File.OpenText(filename);
                int i = 0;
                while (!inputFile.EndOfStream)
                {
                    //Get the input string and split it for every comma
                    drink = inputFile.ReadLine();
                    string[] split = drink.Split(',');
                    //Populate our struct array
                    foreach (string component in split)
                    {
                        drinks[i].name = split[0];
                        drinks[i].cost = Convert.ToDouble(split[1]);
                        drinks[i].quantity = Int32.Parse(split[2]);
                    }
                    i++;
                }
                inputFile.Close();

                //Add costs and show the labels
                label8.Text = "$" + drinks[0].cost.ToString(("F"));
                label9.Text = "$" +  drinks[1].cost.ToString(("F"));
                label10.Text = "$" +  drinks[2].cost.ToString(("F"));
                label11.Text = "$" +  drinks[3].cost.ToString(("F"));
                label12.Text = "$" +  drinks[4].cost.ToString(("F"));
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;

                //Populate quantities
                textBox1.Text = drinks[0].quantity.ToString();
                textBox2.Text = drinks[1].quantity.ToString();
                textBox3.Text = drinks[2].quantity.ToString();
                textBox4.Text = drinks[3].quantity.ToString();
                textBox5.Text = drinks[4].quantity.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //If quantity is over 0, we decrease quantity by 1, and add the cost to the total
           if (drinks[0].quantity > 0)
            {
                //Lower quantity, update total, and update quantity on app
                drinks[0].quantity--;
                total = total + drinks[0].cost;
                textBox6.Text = "$" + total.ToString("F");
                textBox1.Text = drinks[0].quantity.ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //If quantity is over 0, we decrease quantity by 1, and add the cost to the total
            if (drinks[1].quantity > 0)
            {
                //Lower quantity, update total, and update quantity on app
                drinks[1].quantity--;
                total = total + drinks[1].cost;
                textBox6.Text = "$" + total.ToString("F");
                textBox2.Text = drinks[1].quantity.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //If quantity is over 0, we decrease quantity by 1, and add the cost to the total
            if (drinks[2].quantity > 0)
            {
                //Lower quantity, update total, and update quantity on app
                drinks[2].quantity--;
                total = total + drinks[2].cost;
                textBox6.Text = "$" + total.ToString("F");
                textBox3.Text = drinks[2].quantity.ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //If quantity is over 0, we decrease quantity by 1, and add the cost to the total
            if (drinks[3].quantity > 0)
            {
                //Lower quantity, update total, and update quantity on app
                drinks[3].quantity--;
                total = total + drinks[3].cost;
                textBox6.Text = "$" + total.ToString("F");
                textBox4.Text = drinks[3].quantity.ToString();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //If quantity is over 0, we decrease quantity by 1, and add the cost to the total
            if (drinks[4].quantity > 0)
            {
                //Lower quantity, update total, and update quantity on app
                drinks[4].quantity--;
                total = total + drinks[4].cost;
                textBox6.Text = "$" + total.ToString("F");
                textBox5.Text = drinks[4].quantity.ToString();
            }
        }
    }
}
