using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Test
{
    class Order
    {
        private int id;
        private OrderDetail detail;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public OrderDetail Detail
        {
            get { return detail; }
        }
        public Order(int id, string itemName, string customerName,int orderAmount)
        {
            detail = new OrderDetail();
            Id = id;
            detail.ItemName = itemName;
            detail.CustomerName = customerName;
            detail.OrderAmount = orderAmount;
        }
        public void PrintInformation()
        {
            Console.WriteLine("订单号：" + id.ToString() + " 商品名称：" + detail.ItemName + " 用户名称：" + detail.CustomerName + " 订单金额：" + detail.OrderAmount+"\n");
        }
    }

    class OrderDetail
    {
        private string itemname;
        private string customername;
        private int orderamount;
        public string ItemName
        {
            get { return itemname; }
            set { itemname = value; }
        }
        public string CustomerName
        {
            get { return customername; }
            set { customername = value; }
        }
        public int OrderAmount
        {
            get { return orderamount; }
            set { orderamount = value; }
        }
    }

    class OrderService
    {
        private List<Order> orderList;
        private int orderIndex;
        public OrderService()
        {
            orderList = new List<Order>();
            orderIndex = 0;
        }
        public void AddOrder(string itemName, string customerName,int orderAmount)
        {
            orderList.Add(new Order(++orderIndex, itemName, customerName,orderAmount));
        }
        public bool FindOrderById(int id)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    found = true;
                    Console.Write("订单信息为：" + " 商品名称：" + orderList[i].Detail.ItemName + " 用户名称：" + orderList[i].Detail.CustomerName + " 订单金额：" + orderList[i].Detail.OrderAmount + "\n");
                }
            }
            return found;
        }
        public bool FindOrderByItemName(string ItemName)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Detail.ItemName == ItemName)
                {
                    found = true;
                    Console.Write("订单信息为：" + " 商品名称：" + orderList[i].Detail.ItemName + " 用户名称：" + orderList[i].Detail.CustomerName + " 订单金额：" + orderList[i].Detail.OrderAmount + "\n");
                }
            }
            return found;
        }
        public bool FindOrderByCustomerName(string CustomerName)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Detail.CustomerName == CustomerName)
                {
                    found = true;
                    Console.Write("订单信息为：" + " 商品名称：" + orderList[i].Detail.ItemName + " 用户名称：" + orderList[i].Detail.CustomerName + " 订单金额：" + orderList[i].Detail.OrderAmount + "\n");
                }
            }
            return found;
        }
        public bool CheckOverTenThousand(int OrderAmount)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Detail.OrderAmount > 10000)
                {
                    found = true;
                    Console.Write("订单信息为：" + " 商品名称：" + orderList[i].Detail.ItemName + " 用户名称：" + orderList[i].Detail.CustomerName + " 订单金额：" + orderList[i].Detail.OrderAmount + "\n");
                }
            }
            return found;
        }
        public bool DeleteOrder(int id)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    found = true;
                    orderList.Remove(orderList[i]);
                }
            }
            return found;
        }
        public bool UpdateOrderCustomerName(int id, string CustomerName)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    found = true;
                    orderList.Remove(orderList[i]);
                }
            }
            return found;
        }
        
        public bool UpdateOrderItemName(int id, string ItemName)
        {
            bool found = false;
            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].Id == id)
                {
                    found = true;
                    orderList.Remove(orderList[i]);
                }
            }
            return found;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            while (true)
            {
                Console.WriteLine("输入:\na:添加订单\nb:查询订单\nc:删除订单\nd:修改订单");
                string command = Console.ReadLine();
                if (command == "a")
                {
                    Console.WriteLine("输入:商品名称");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("输入:客户名称");
                    string name2 = Console.ReadLine();
                    Console.WriteLine("输入:商品金额");
                    int amount1 = Convert.ToInt32(Console.ReadLine());
                    service.AddOrder(name1, name2,amount1);
                }
                else if (command == "b")
                {
                    Console.WriteLine("输入:\na:通过id查询\nb:通过商品名称查询\nc:通过客户名称查询\nd:订单金额大于1万元的订单");
                    string command2 = Console.ReadLine();
                    string info = Console.ReadLine();
                    bool succ = true;
                    if (command2 == "a")
                    {
                        succ = service.FindOrderById(Convert.ToInt32(info));
                    }
                    else if (command2 == "b")
                    {
                        succ = service.FindOrderByItemName(info);
                    }
                    else if (command2 == "c")
                    {
                        succ = service.FindOrderByCustomerName(info);
                    }
                    else if (command2 == "d")
                    {
                        succ = service.CheckOverTenThousand(Convert.ToInt32(info));
                    }

                        if (succ == false) Console.WriteLine("未找到商品");
                }
                else if (command == "c")
                {
                    Console.WriteLine("输入:删除商品ID");
                    string id = Console.ReadLine();
                    bool succ = service.DeleteOrder(Convert.ToInt32(id));
                    if (succ == false) Console.WriteLine("未找到商品\n");
                }
                else if (command == "d")
                {
                    Console.WriteLine("输入:修改商品ID");
                    string id = Console.ReadLine();
                    Console.WriteLine("输入:\na:修改商品名称\nb:修改客户名称");
                    string command2 = Console.ReadLine();
                    bool succ = true;
                    string Name = Console.ReadLine();
                    if (command2 == "a")
                    {
                        succ = service.UpdateOrderItemName(Convert.ToInt32(id), Name);
                    }
                    else if (command2 == "b")
                    {
                        succ = service.UpdateOrderCustomerName(Convert.ToInt32(id), Name);
                    }
                    if (succ == false) Console.WriteLine("未找到商品\n");

                }
            }
        }
    }
}
