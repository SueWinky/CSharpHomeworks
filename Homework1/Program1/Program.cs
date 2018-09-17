using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("输入第一个数：");
            string d1 = Console.ReadLine();
            Console.Write("输入第二个数：");
            string d2 = Console.ReadLine();
            Console.WriteLine("两个个数的乘积是:{0}", Convert.ToInt32(d1) * Convert.ToInt32(d2));
        }
    }

}
