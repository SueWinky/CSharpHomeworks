using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace OrderWinForm
{
    public partial class Form1 : Form
    {
        private List<Order> list;
        private OrderService service;
        public Form1()
        {
            InitializeComponent();
            service = OrderService.Import("../../s.xml");
            orderBindingSource.DataSource = service.OrderList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {
                int row = e.RowIndex;

                string name = (string) ((DataGridView)sender).Rows[row].Cells[0].Value;
                string client = (string)((DataGridView)sender).Rows[row].Cells[1].Value;
                string id = (string)((DataGridView)sender).Rows[row].Cells[2].Value;
                ((DataGridView)sender).Rows.RemoveAt(row);
                Order order = service.OrderList
                    .Where(s =>
                    s.Client == client &&
                    s.Id == id &&
                    s.Name == name)
                    .FirstOrDefault();
                service.OrderList.Remove(order);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int row = e.RowIndex;

                string name = (string)((DataGridView)sender).Rows[row].Cells[0].Value;
                double count = (double)((DataGridView)sender).Rows[row].Cells[1].Value;
                double price = (double)((DataGridView)sender).Rows[row].Cells[2].Value;
                ((DataGridView)sender).Rows.RemoveAt(row);
                List<OrderDetails> details = (List<OrderDetails>)((DataGridView)sender).DataSource;
                OrderDetails detail = details
                    .Where(s =>
                    count == s.Count &&
                    name == s.Name &&
                    price == s.Price)
                    .FirstOrDefault();
                details.Remove(detail);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            orderBindingSource.DataSource = service.OrderList.
                Where(s =>
                s.Client.Contains(text) ||
                s.Id.Contains(text) ||
                s.Name.Contains(text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(this.textBox1.Text=="")
            {
                orderBindingSource.DataSource = service.OrderList;
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.Export("../../s.xml");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service.ExportHtml("../../s.html");
        }
    }
}
