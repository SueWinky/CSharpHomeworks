using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomeworkProject1
{
    [Serializable]
    public class Goods
    {
        private double price;

        public uint Id { get; set; }

        public string Name { get; set; }

        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("价格必须大于0");
                price = value;
            }
        }

        public Goods(uint id = 0, string name = "",double value = 0)
        {
            Id = id;
            Name = name;
            Price = value;
        }

        public Goods()
        {
            Id = 0;
            Name = "";
            Price = 0;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Value:{Price}";
        }
    }
}
