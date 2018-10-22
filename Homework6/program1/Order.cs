using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Order
{
        private List<OrderDetails> data;
        private String client;
        private String id;
        private String name;
        public Order()
        {
            data = new List<OrderDetails>();
            client = "";
            DateTime dateTime = DateTime.Now;
            id = dateTime.ToString();
            name = "";
        }
        public Order(String client, String name = "")
        {
            DateTime dateTime = DateTime.Now;
            id = dateTime.ToString();
            this.client = client;
            this.name = name;
            data = new List< OrderDetails>();
        }

        public String Name { get => name; set => name = value; }
        public String Client { get => client; set => client = value; }
        public String Id { get => id; set => id = id; }
        public List<OrderDetails> Data { get => data; }

        public Double GetSum()
        {
            double prices = data
                .Select(detail => detail.Count * detail.Price)
                .Sum();
            return prices;
        }

        public void AddDetail(String name, double count, double price)
        {
            var select = data
                .Where(d => d.Name == name)
                .Select(d => d)
                .FirstOrDefault();
            if(select == null)
            {
                data.Add(new OrderDetails(price, count, name));
            }
            else
            {
                if(select.Price!=price)
                {
                    return;
                }
                select.Count += count;
            }
        }

        public void DeleteDetail(String name)
        {
            foreach(OrderDetails detail in data)
            {
                if(detail.Name == name)
                {
                    data.Remove(detail);
                }
            }
        }

        public void ChangeCount(String name, double count)
        {
            var select = data.Where(s => s.Name == name).Select(s => s).FirstOrDefault();
            if (select==null)
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            select.Count = count;
        }

        public void ChangePrice(String name, double price)
        {
            var select = data.Where(s => s.Name == name).Select(s => s).FirstOrDefault();
            if (select==null)
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            select.Price = price;
        }

        public void Print()
        {
            foreach (OrderDetails item in data)
            {
                Console.WriteLine($"名称：{item.Name}, 价格：{item.Price}， 数目：{item.Count}");
            }
        }
}
