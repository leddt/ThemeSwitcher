using System;
using System.Windows.Forms;

namespace ThemeSwitcher.Forms
{
    public partial class EnterThemeNameDialog : Form
    {
        public string ThemeName
        {
            get { return ThemeNameTextBox.Text; }
            set
            {
                ThemeNameTextBox.Text = value;
                ThemeNameTextBox.SelectAll();
            }
        }

        public EnterThemeNameDialog()
        {
            InitializeComponent();

            ThemeNameTextBox.Focus();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ThemeNameTextBox_TextChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = ThemeNameTextBox.Text.Trim() != "";
        }
    }
}
