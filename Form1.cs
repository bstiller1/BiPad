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

namespace BiPad
{
    public partial class Form1 : Form
    {
        public string FileName;

        public Form1()
        {
            InitializeComponent();
        }
        
        // File -> Close - File Menu Action
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

        // File -> File Save - File Menu Action
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the Global FileName exists
            if (FileName != null)
            {
                saveFileDialog1.OverwritePrompt = false;
                
                // Write text to file
                using (StreamWriter sw = new StreamWriter(FileName))
                    sw.WriteLine(richTextBox1.Text);

                //sw.Close();
                GC.Collect();
            }
            else
            {
                // Write text to file
                using (StreamWriter sw = new StreamWriter(FileName))
                    sw.WriteLine(richTextBox1.Text);
            }

        }

        // File -> Save As - File Menu Action
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  This is for "Save As" dialog
            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            // Save as Type: All Files and Text .txt Files
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // Initial Default Save Directory "My Documents"
            saveFileDialog1.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.FilterIndex = 2;
            // Open last directory opened
            saveFileDialog1.RestoreDirectory = true;
            // If user clicked OK
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                // Create StreamWriter Object to write the file
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    sw.WriteLine(richTextBox1.Text);
                // setting the global variable
                FileName = saveFileDialog1.FileName;
                
                //MessageBox.Show("Current FileName: " + FileName);
                GC.Collect();
                // myStream.Close();
            }
            // User did not select a file name and closed the dialog
            else if (saveFileDialog1.OpenFile() == null)
            {

            }
            // User did not select a file name and clicked Cancel
            else if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {

            }
            else
            {
                MessageBox.Show("That file is already open");
            }

        }

        // File -> Open - File Menu Action
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Open Default Directory "My Documents"
            openFileDialog1.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // Open Type: All Files and Text .txt Files
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            // Open last directory opened
            openFileDialog1.RestoreDirectory = true;

            // If the user clicks OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Create StreamWriter Object to open the file
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        // Read the entire file into buffer
                        String line = sr.ReadToEnd();
                        // Put the file contents in the richTextBox1
                        richTextBox1.Text = line;
                    }
                }
                    // If there is any problem reading the file
                catch (Exception ex)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}


