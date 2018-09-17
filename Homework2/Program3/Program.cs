using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(2 + " ");
            for (int m = 3; m <= 100; m += 2)
            {
                bool a = true;
                if (m % 2 == 0)
                {
                    a = false;
                }
                else
                {
                    for (int i = 3; i < m / 2; i += 2)
                    {
                        if (m % i == 0)
                        {
                            a = false;
                            break;
                        }
                    }
                }
                if (a == true)
                {
                    Console.Write(m.ToString() + " ");
                }
            }
            Console.WriteLine();
        }
    }
}