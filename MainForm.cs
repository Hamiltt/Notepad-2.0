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

namespace Notepad_2._0
{
    public partial class MainForm : Form
    {
        private string fileName = "";
        private readonly byte mainBackColorR;
        private readonly byte mainBackColorG;
        private readonly byte mainBackColorB;
        public MainForm()
        {
            InitializeComponent();
            mainBackColorR = BackColor.R;
            mainBackColorG = BackColor.G;
            mainBackColorB = BackColor.B;
        }

        private void ClearToolStripMenuItemClick(object sender, EventArgs e)
        {
            mainTextBox.Clear();
            Text = "Notepad 2.0";
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                fileName = openFileDialog1.FileName;
                Text = $"Notepad 2.0 {fileName}";
                mainTextBox.Text = File.ReadAllText(fileName, Encoding.UTF8);
            }
            catch { }
        }

        private void SaveToolStripMenuItem1Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.ShowDialog(mainTextBox);
                fileName = saveFileDialog1.FileName;
                Text = $"Notepad 2.0 {fileName}";
                File.WriteAllText(fileName, mainTextBox.Text, Encoding.UTF8);
            }
            catch { }
        }

        private void FontToolStripMenuItemClick(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            mainTextBox.Font = fontDialog1.Font;
        }

        private void FileToolStripMenuItemDropDownOpened(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
        }

        private void FileToolStripMenuItemDropDownClosed(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.White;
        }

        private void FormatToolStripMenuItemDropDownOpened(object sender, EventArgs e)
        {
            formatToolStripMenuItem.ForeColor = Color.Black;
        }

        private void FormatToolStripMenuItemDropDownClosed(object sender, EventArgs e)
        {
            formatToolStripMenuItem.ForeColor = Color.White;
        }

        private void FontColorToolStripMenuItemClick(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            mainTextBox.ForeColor = colorDialog1.Color;
        }

        private void BackgroundColorToolStripMenuItemClick(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            mainTextBox.BackColor = colorDialog1.Color;
            menuStrip1.BackColor = colorDialog1.Color;
            if (colorDialog1.Color.R > 200 && colorDialog1.Color.G > 200 && colorDialog1.Color.B > 200)
            {
                fileToolStripMenuItem.ForeColor = Color.Black;
                formatToolStripMenuItem.ForeColor = Color.Black;
            }
            else if (colorDialog1.Color == Color.Yellow || colorDialog1.Color == Color.Green || colorDialog1.Color == Color.Blue)
            {
                fileToolStripMenuItem.ForeColor = Color.Black;
                formatToolStripMenuItem.ForeColor = Color.Black;
            }
        }

        private void ResetSettingsToolStripMenuItemClick(object sender, EventArgs e)
        {
            mainTextBox.ForeColor = Color.White;
            mainTextBox.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mainTextBox.BackColor = Color.FromArgb(mainBackColorR, mainBackColorG, mainBackColorB);
            menuStrip1.BackColor = Color.FromArgb(mainBackColorR, mainBackColorG, mainBackColorB);
            Opacity = 0.97d;
        }

        private void OpacityToolStripMenuItemClick(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this, SettingsTypes.Opacity, mainTextBox.BackColor);
            settingsForm.Show();
        }
    }

    public enum SettingsTypes
    {
        Opacity
    }
}
