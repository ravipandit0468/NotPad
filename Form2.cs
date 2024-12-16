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
using System.Windows.Forms.VisualStyles;//Input-Output with the files/folders

namespace ADODotNetAppn
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK) 
            {
                var stream = new FileStream(saveFileDialog1.FileName,FileMode.OpenOrCreate,FileAccess.Write);
                StreamWriter sw = new StreamWriter(stream);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                stream.Close();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var stream = new FileStream(openFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(stream);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                stream.Close();
            }
        }

        private void cutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void allTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void allTextFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void selectedTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SelectionColor = colorDialog.Color;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select The Text To Change It's Color!");
            }
        }

        private void selectedTextFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength>0)
            {
                using (FontDialog fontDialog = new FontDialog())
                {
                    if (fontDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SelectionFont = fontDialog.Font;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select The Text To Change It's Font!");
            }
        }
        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor += 1;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor -= 1;
        }
    }
}
