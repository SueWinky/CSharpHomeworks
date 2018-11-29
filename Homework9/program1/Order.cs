using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace program1
{
    [Serializable]
    public class Order
    {
        [Key]
        public string OrderNum { set; get; }

        public string ClientName { set; get; }

        public string PhoneNum { set; get; }
      
        public decimal TotalMoney
        {
            get
            {
                decimal totalMoney = OrderDetails
                 .Select(detail => detail.ProductsNum * detail.Price)
                 .Sum();
                return totalMoney;
            }
        }

        public Order() {
            OrderNum= DateTime.Now.Year.ToString() + '-'
                    + DateTime.Now.Month.ToString() + '-'
                    + DateTime.Now.Day.ToString() + '-'
                    + GenerateRandomCode(3);
        }

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public void AddOrderDetails(OrderDetail orderDetails) => this.OrderDetails.Add(orderDetails);

        public void RemoveOrderDetails(OrderDetail orderDetails) => this.OrderDetails.Remove(orderDetails);

        public void ClearOrderDetails() => OrderDetails.Clear();

        public decimal GetTotalMoney()
        {
            decimal totalMoney = OrderDetails
                  .Select(detail => detail.ProductsNum * detail.Price)
                  .Sum();
            return totalMoney;
        }

        public string GenerateRandomCode(int length)
        {
            var result = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10));
            }
            return result.ToString();
        }
    }
}
