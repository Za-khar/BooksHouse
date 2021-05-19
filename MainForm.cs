using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksHouse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void TextBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void TextBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void TextBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
    }
}
