using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        int a, b;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text.ToString());
        }
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            b = Convert.ToInt32(textBox2.Text.ToString());
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "两数之积为：" + (a * b).ToString();
        }
    }
}
