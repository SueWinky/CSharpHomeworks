using System;

[Serializable]
    public class OrderDetails
    {
        private double price;
        private double count;
        private String name;

        public OrderDetails()
        {
            price = 0;
            count = 0;
            name = "";
        }
        public OrderDetails(double price, double count, String name)
        {
            this.price = price;
            this.count = count;
            this.name = name;
        }

        //封装属性
        public double Price { get => price; set => price = value; }
        public double Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
    }
