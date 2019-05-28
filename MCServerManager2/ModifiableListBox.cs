using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCServerManager2
{
    public partial class ModifiableListBox : UserControl
    {
        public ModifiableListBox()
        {
            InitializeComponent();
        }

        public string[] Values { get {
                string[] tmp = new string[listBox1.Items.Count];
                for(int i = 0; i < tmp.Length; i++) tmp[i] = (string)listBox1.Items[i];
                return tmp;
            } }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Contains(textBox1.Text))
            {
                listBox1.Items.Remove(textBox1.Text);
            }
        }
    }
}
