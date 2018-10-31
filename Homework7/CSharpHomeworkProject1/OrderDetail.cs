using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHomeworkProject1
{
    [Serializable]
    public class OrderDetail
    {
        public uint Id { get; set; }

        public Goods Goods { get; set; }

        public uint Quantity { get; set; }

        public OrderDetail(uint id = 0,Goods goods = null,uint quantity = 0)
        {
            Id = id;
            Goods = goods;
            Quantity = quantity;
        }

        public OrderDetail()
        {
            Id = 0;
            Goods = null;
            Quantity = 0;
        }

        public override bool Equals(object obj)
        {
            OrderDetail detail = obj as OrderDetail;
            return detail != null && Goods.Id == detail.Goods.Id && Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"orderDetailId:{Id}:  " + Goods.ToString() + $", quantity:{Quantity}";
        }
    }
}
