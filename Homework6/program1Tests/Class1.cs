using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using program1;
namespace program1Tests
{
    class Class1
    {
        static void Main(string[] args)
        {
            OrderService service = OrderService.Import("s.xml");
        }
        
    }
}
