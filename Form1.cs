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
using GlobalVariables;

namespace BiPad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a MsgBox asking the user to save changes or abort. 
            if (MessageBox.Show("Do you want to save changes to your text?", "BiPad",
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Call method to save file...
            }
            else
            {
                // The user wants to exit the application. Close everything down.
                Application.Exit();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check to see that the filename exists
            if (saveFileDialog1.CheckFileExists == true)
            {
                saveFileDialog1.OverwritePrompt = false;
                // Code to write the stream goes here.
                // accessing the global variable
                string currentFileName = Globals.GlobalName;
                using (StreamWriter sw = new StreamWriter(currentFileName))
                    sw.WriteLine(richTextBox1.Text);

                //sw.Close();
                GC.Collect();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  This is for "Save As" dialog
            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  if ((myStream = saveFileDialog1.OpenFile()) != null)
                //  {
                // Code to write the stream goes here.
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    sw.WriteLine(richTextBox1.Text);
                // setting the global variable
                Globals.SetGlobalName(saveFileDialog1.FileName);
                GC.Collect();
                // myStream.Close();
            }
            else
            {
                MessageBox.Show("That file is already open");
            }

        }
    }
}


