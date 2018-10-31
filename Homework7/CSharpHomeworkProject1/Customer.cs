using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomeworkProject1
{
    [Serializable]
    public class Customer
    {
        public uint Id { get; set; }

        public string Name { get; set; }

        public Customer(uint id = 0,string name = "")
        {
            Id = id;
            Name = name;
        }

        public Customer()
        {
            Id = 0;
            Name = "";
        }

        public override string ToString()
        {
            return $"customerId:{Id}, CustomerName:{Name}";
        }
    }
}
