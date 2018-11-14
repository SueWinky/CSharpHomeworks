using System;
using System.Runtime.Serialization;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Order myOrder = new Order("Sue", "firstOrder");
            myOrder.AddDetail("Dell", 4, 8000);           
            myOrder.Tel = "+61919921222";
            Order newOrder = new Order("Sue", "secondOrder");
            newOrder.AddDetail("ThinkPad", 44, 6000);
            newOrder.AddDetail("Lenovo", 14, 5000);
            newOrder.Tel = "+61919910221";
            OrderService service = new OrderService();
            service.AddOrder(myOrder);
            service.AddOrder(newOrder);
            service.Export();
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




