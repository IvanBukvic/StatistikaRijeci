using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatistikaRijeci
{
    public partial class Forma : Form
    {
        public Forma()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void file_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        public void OpenFile()
        {
            OpenFileDialog openfile = new OpenFileDialog
            {
                Filter = "Text File|*.txt",
                Title = "Open a Text File"
            };

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openfile.FileName);
                UnosText.Text = reader.ReadToEnd();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseApplication();            
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (UnosText.Text == String.Empty)
            {
                MessageBox.Show("Input is empty! Please enter text or choose a file.", "Error!");
            }
            else
            {
                IznosText.Clear();
                Dictionary<string, int> wordDictionary = new Dictionary<string, int>();
                string line;

                for (int i = 0; i < UnosText.Lines.Length; i++)
                {

                    line = UnosText.Lines[i].ToLower();                    
                    line = Regex.Replace(line, @"[^a-z ]", String.Empty);
                    string[] words = line.Split();

                    foreach (string word in words)
                    {

                        if (word.Length < 2) {
                            continue;
                        } 
                        if (wordDictionary.ContainsKey(word) == true)
                        {
                            wordDictionary[word]++;
                        }
                        else
                        {
                            wordDictionary.Add(word, 1);
                        }
                    }
                }

                var newList = wordDictionary.OrderByDescending(x => x.Value).ToList();
                IznosText.Text = "Word   -   Number" + Environment.NewLine;
                IznosText.Text += "---------------------------------------------------" + Environment.NewLine;
                IznosText.Text += Environment.NewLine;

                foreach (KeyValuePair<string, int> pair in newList)
                {
                    string par = $"{pair.Key} - {pair.Value}";
                    IznosText.Text += par + Environment.NewLine;
                }
            }
            
        }       

        public void CloseApplication()
        {
            string message = "Do you want to close this application?";
            string title = "Close Application";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
       
    }
}
