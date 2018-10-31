using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace CSharpHomeworkProject1
{
    public class OrderService
    {
        private Dictionary<uint, Order> orderDict;
        
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
            {
                // throw new Exception("该订单已存在");
                return;
            }
            orderDict[order.Id] = order;
        }

        public void RemoveOrder(uint orderId)
        {
            if(orderDict.ContainsKey(orderId))
                orderDict.Remove(orderId);
        }

        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        public Order GetById(uint orderId)
        {
            if (orderDict.ContainsKey(orderId))
                return orderDict[orderId];
            else return null;
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            var query = orderDict.Values.Where(order =>
                        order.Details.Where(d => d.Goods.Name == goodsName).Count() > 0);
            return query.ToList();
        }

        public List<Order> QueryByCustomerName(string customName)
        {
            var query = orderDict.Values.Where(order => order.Customer.Name == customName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values.Where(order => order.Amount > price);
            return query.ToList();
        }

        public void UpdataCustomer(uint orderId,Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                // throw new Exception("该订单不存在");
                return;
            }
        }

        public void Export()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderDict.Values.ToList());
            }
        }

        public void Import()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("s.xml", FileMode.Open))
            {
                List<Order> orders = xmlSerializer.Deserialize(fs) as List<Order>;
                foreach (Order order in orders)
                {
                    AddOrder(order);
                }
            }
        }
    }
}
