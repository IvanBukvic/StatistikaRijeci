using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
