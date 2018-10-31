using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpHomeworkProject1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            foreach(Order o in Form1.orders)
            {
                comboBox1.Items.Add(o.Id);
            }
            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                case "订单ID":
                    Form1.orders[comboBox1.SelectedIndex].Id = uint.Parse(textBox1.Text);
                    break;
                case "客户ID":
                    Form1.orders[comboBox1.SelectedIndex].Customer.Id = uint.Parse(textBox1.Text);
                    break;
                case "客户名":
                    Form1.orders[comboBox1.SelectedIndex].Customer.Name = textBox1.Text;
                    break;
            }

            new Form5().ShowDialog();
        }
    }
}
