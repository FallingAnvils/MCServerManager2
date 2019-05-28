using System;
using System.Windows.Forms;

namespace MCServerManager2
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => this.Close();
    }
}
