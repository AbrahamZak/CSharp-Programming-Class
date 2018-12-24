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

namespace WorldSeriesWinners
{
    public partial class Form1 : Form
    {
        //List that will hold the wins for each team
        List<int> finalWins = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get the filename and load the contents into our listbox
            string filename;
            GetFileName(out filename);
            GetTeams(filename);
            label3.Text = filename + " is loaded.";
            label1.Visible = true;
            label3.Visible = true;
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

        //Method to get team names from the text file and list them in the listbox
        private void GetTeams(String filename)
        {
            try
            {
                string teamName;
                StreamReader inputFile;
                inputFile = File.OpenText(filename);
                teamListBox.Items.Clear();
                while (!inputFile.EndOfStream)
                {
                    teamName = inputFile.ReadLine();
                    teamListBox.Items.Add(teamName);
                }
                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Method to get total wins  for each team and store them in our int array
        private void GetWins(String filename)
        {
            //Initialize our int array for the amount of teams
            try
            {
                for (int i = 0; i< teamListBox.Items.Count; i++)
                {
                    finalWins.Add(0);
                }
                //Read the file
                string teamName;
                StreamReader inputFile;
                inputFile = File.OpenText(filename);
                //For each line in the text box we check for a match in our listbox, when a match is found we increment that index in our array by 1
                while (!inputFile.EndOfStream)
                {
                    teamName = inputFile.ReadLine();
                    foreach (var listBoxItem in teamListBox.Items)
                    {
                        String curWinner = listBoxItem.ToString();
                        if (teamName.CompareTo(curWinner) == 0)
                        {
                            finalWins[teamListBox.Items.IndexOf(curWinner)]++;
                        }
                    }
                }
                //Go through the wins array and find the highest amount, then store that amount and finally put it in our textbox with the team name at that index
                int highestWins = 0;
                int highestWinsPosition = 0;
                for (int i = 0; i < finalWins.Count; i++)
                {
                    if (finalWins[i] > highestWins)
                    {
                        highestWins = finalWins[i];
                        highestWinsPosition = i;
                    }
                }
                //Go through the wins array and find the lowest amount, then store that amount and finally put it in our textbox with the team name at that index
                String highest = teamListBox.Items[highestWinsPosition].ToString();
                label8.Text = (highest + " with " + highestWins.ToString() + " wins.");

                int lowestWins = 100;
                int lowestWinsPosition = 0;
                for (int i = 0; i < finalWins.Count; i++)
                {
                    if (finalWins[i] < lowestWins)
                    {
                        lowestWins = finalWins[i];
                        lowestWinsPosition = i;
                    }
                }
                String lowest = teamListBox.Items[lowestWinsPosition].ToString();
                label9.Text = (lowest + " with " + lowestWins.ToString() + " wins.");

                inputFile.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Loads wins fine and process it
        private void button2_Click(object sender, EventArgs e)
        {
            string filename;
            GetFileName(out filename);
            GetWins(filename);
            label4.Text = filename + " is loaded.";
            label2.Visible = true;
            label4.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }
        //Close the program
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //When the selection changes on the listbox, find the wins for that index and put it on the label
        private void teamListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            label11.Text = finalWins[teamListBox.SelectedIndex].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}

