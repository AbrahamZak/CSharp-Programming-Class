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

namespace EmailAddressBook
{
    public partial class Form1 : Form
    {
        List<PersonEntry> People = new List<PersonEntry>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string Person;
                StreamReader inputFile = new StreamReader("C:\\PersonList.txt");
                while (!inputFile.EndOfStream)
                {
                    Person = inputFile.ReadLine();
                    string[] split = Person.Split(',');
                    var person = new PersonEntry(split[0], split[1], split[2]);
                    People.Add(person);
                }
                inputFile.Close();
                foreach (var PersonEntry in People)
                {
                    listBox1.Items.Add(PersonEntry.name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = People[listBox1.SelectedIndex].name;
            String email = People[listBox1.SelectedIndex].email;
            String phone = People[listBox1.SelectedIndex].phone;
            this.Hide();
            Form2 m = new Form2(name, email, phone);
            m.Show();
        }
    }
}
