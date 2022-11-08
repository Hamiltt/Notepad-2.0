using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_2._0
{
    public partial class SettingsForm : Form
    {
        MainForm mainForm;
        double newOpacity;
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(MainForm mainForm, SettingsTypes settingType, Color textBoxBackColor)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            BackColor = textBoxBackColor;
            Opacity = mainForm.Opacity;
            if (settingType == SettingsTypes.Opacity)
            {
                Text = $"{settingType}";
                Width = 250;
                Height = 140;
                trackBarOpacity.Value = (int)(mainForm.Opacity * 100);
                label1.Text = $"Current Opacity: {trackBarOpacity.Value}%";
            }
        }

        private void TrackBarOpacityScroll(object sender, EventArgs e)
        {
            label1.Text = $"Current Opacity: {trackBarOpacity.Value}%";
            newOpacity = (double)trackBarOpacity.Value / 100;
            UpdateOpacity(mainForm, newOpacity);
        }

        private void UpdateOpacity(MainForm mainForm, double newOpacity)
        {
            Opacity = newOpacity;
            mainForm.Opacity = newOpacity;
        }
    }
}
