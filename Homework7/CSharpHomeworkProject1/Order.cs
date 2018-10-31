using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomeworkProject1
{
    [Serializable]
    public class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();

        public uint Id { get; set; }

        public Customer Customer { get; set; }

        public Order(uint id = 0,Customer customer = null)
        {
            Id = id;
            Customer = customer;
        }

        public Order()
        {
            Id = 0;
            Customer = null;
        }

        public double Amount
        {
            get
            {
                return details.Sum(d => d.Goods.Price * d.Quantity);
            }
        }

        public List<OrderDetail> Details
        {
            get { return this.details; }
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if (Details.Contains(orderDetail))
            {
                throw new Exception("此订单明细已经存在");
            }
            details.Add(orderDetail);
        }

        public void RemoveDetails(uint detailId)
        {
            details.RemoveAll(d => d.Id == detailId);
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer.Name}),Amount:{Amount}";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }
    }
}
