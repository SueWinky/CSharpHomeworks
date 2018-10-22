using System;
using System.Runtime.Serialization;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Order myOrder = new Order("Sue", "firstOrder");
            myOrder.AddDetail("lenovo", 4, 6000);
            Order newOrder = new Order("Sue", "secondOrder");
            newOrder.AddDetail("Dell", 44, 7000);
            myOrder.AddDetail("Thinkpad", 14, 5000);
            OrderService service = new OrderService();
            service.AddOrder(myOrder);
            service.AddOrder(newOrder);
            service.Export();
            OrderService newService = OrderService.Import("i.xml");
            newService.Export("e.xml");
        }
    }
}

class CanNotFindOrder : ApplicationException
{
    public CanNotFindOrder(String message) : base(message) { }
}

class CanNotFindEntry : ApplicationException
{
    public CanNotFindEntry(String message) : base(message) { }
}




