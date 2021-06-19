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

namespace OpenNote
{
    public partial class Form1 : Form
    {
        string[] notes;
        static string UserName = Environment.UserName;
        string NotePath = "C:\\Users\\" + UserName + "\\OpenNote";
        string FileToDelete;

        void CreateFolder() 
        {
            if (!Directory.Exists(NotePath))
            {
                Directory.CreateDirectory(NotePath);
            }
        }

        void CheckFiles() 
        {
            listBox1.Items.Clear();
            notes = Directory.GetFiles(NotePath);
            listBox1.Items.AddRange(notes);
        }

        public Form1()
        {
            InitializeComponent(); //always first
            CreateFolder();
            CheckFiles();

        }

        void LightTheme()
        {
            this.BackColor = Color.FromArgb(255, 240, 240, 240);
            menuStrip1.BackColor = Color.Transparent;
            textBox1.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            listBox1.BackColor = Color.White;
        }

        void DarkTheme()
        {
            this.BackColor = Color.FromArgb(255, 99, 99, 99);
            menuStrip1.BackColor = Color.FromArgb(255, 99, 99, 99);
            textBox1.BackColor = Color.FromArgb(255, 160, 160, 160);
            richTextBox1.BackColor = Color.FromArgb(255, 160, 160, 160);
            listBox1.BackColor = Color.FromArgb(255, 160, 160, 160);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //open
            if(listBox1.SelectedItem != null)
            {
                string note = listBox1.SelectedItem.ToString();
                string LabelNote = note.Substring(NotePath.Length + 1, note.Length - NotePath.Length - 5);
                FileToDelete = note;
                try
                {
                    textBox1.Text = LabelNote;
                    using (StreamReader sr = new StreamReader(note))
                    {

                        richTextBox1.Text = sr.ReadToEnd();
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                CheckFiles();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete
            if (File.Exists(FileToDelete))
            {
                File.Delete(FileToDelete);
            }
            CheckFiles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //save
            if (textBox1.Text != "")
            {
                string NoteName = textBox1.Text;
                string NoteMain = richTextBox1.Text;
                string note = "C:\\Users\\" + UserName + "\\OpenNote\\" + NoteName + ".txt";

                try
                {
                    using (StreamWriter sw = new StreamWriter(note, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(NoteMain);
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }

            }
            if (FileToDelete != "")
            {
                File.Delete(FileToDelete);
            } 
            CheckFiles();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dark
            DarkTheme();
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Light
            LightTheme();
        }
    }
}
