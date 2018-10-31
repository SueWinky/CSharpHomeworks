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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(uint.Parse(textBox3.Text), textBox4.Text);
            Order order = new Order(uint.Parse(textBox1.Text), customer);
            Form1.orders.Add(order);
      
            this.Close();
        }
    }
}
