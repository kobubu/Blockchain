using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Blockchain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Chain _chain = new Chain();

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _chain.Add(textBox1.Text, "User");
            textBox1.Clear();
            listBox1.Items.AddRange(_chain.Blocks.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                listBox1.Items.AddRange(_chain.Blocks.ToArray());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
