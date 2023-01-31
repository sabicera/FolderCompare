using System.Windows.Forms;
using System;
using System.IO;

namespace FolderCompare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string folder1 = folder1TextBox.Text;
            string folder2 = folder2TextBox.Text;

            if (!Directory.Exists(folder1) || !Directory.Exists(folder2))
            {
                MessageBox.Show("One of the folders does not exist.");
                return;
            }

            string[] files1 = Directory.GetFiles(folder1, "*.*", SearchOption.AllDirectories);
            string[] files2 = Directory.GetFiles(folder2, "*.*", SearchOption.AllDirectories);

            foreach (string file1 in files1)
            {
                string file2 = file1.Replace(folder1, folder2);
                if (!File.Exists(file2))
                {
                    listBox1.Items.Add(file1 + " does not exist in " + folder2);
                }
                else
                {
                    FileInfo info1 = new FileInfo(file1);
                    FileInfo info2 = new FileInfo(file2);
                    if (info1.Length != info2.Length)
                    {
                        listBox1.Items.Add(file1 + " and " + file2 + " have different sizes.");
                    }
                }
            }

            foreach (string file2 in files2)
            {
                string file1 = file2.Replace(folder2, folder1);
                if (!File.Exists(file1))
                {
                    listBox1.Items.Add(file2 + " does not exist in " + folder1);
                }
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            string folder1 = folder1TextBox.Text;
            string folder2 = folder2TextBox.Text;

            if (!Directory.Exists(folder1) || !Directory.Exists(folder2))
            {
                MessageBox.Show("One of the folders does not exist.");
                return;
            }

            string[] files1 = Directory.GetFiles(folder1, "*.*", SearchOption.AllDirectories);

            foreach (string file1 in files1)
            {
                string file2 = file1.Replace(folder1, folder2);
                if (!File.Exists(file2))
                {
                    File.Copy(file1, file2);
                }
            }

            MessageBox.Show("Files copied successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial directory to "My Computer".
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            // Show the folder browser and check the result.
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected folder's path.
                string selectedFolder = folderBrowserDialog.SelectedPath;

                // Set the selected folder path to the folder1TextBox.Text property.
                folder1TextBox.Text = selectedFolder;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the initial directory to "My Computer".
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            // Show the folder browser and check the result.
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected folder's path.
                string selectedFolder = folderBrowserDialog.SelectedPath;

                // Set the selected folder path to the folder1TextBox.Text property.
                folder2TextBox.Text = selectedFolder;
            }
        }
    }
}