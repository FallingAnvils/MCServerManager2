using System;
using System.Media;
using System.Windows.Forms;

namespace MCServerManager2
{
    public partial class TextPrompt : Form
    {
        private bool _whitespaceAllowed;
        public TextPrompt(string text, string title, bool canBeEmptyOrWhitespace, bool password)
        {
            InitializeComponent();
            label1.Text = text;
            this.Text = title;
            _whitespaceAllowed = canBeEmptyOrWhitespace;
            textBox1.UseSystemPasswordChar = password;
        }

        public static string Prompt(string text, string title, bool canBeEmptyOrWhitespace, bool password)
        {
            var prompt = new TextPrompt(text, title, canBeEmptyOrWhitespace, password);
            var result = prompt.ShowDialog();
            if (result == DialogResult.OK)
                return prompt.textBox1.Text;
                else return null;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if(!_whitespaceAllowed && textBox1.Text.IsNullOrWhiteSpace())
            {
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Value cannot be empty");
            }
            else
            {
                _success = true;
                this.Close();
            }
        }

        bool _success = false;

        private void TextPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = _success ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
