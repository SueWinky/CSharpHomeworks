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
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i <= n - 1; i++)
            {
                if (n % i == 0)
                {
                    bool right = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if(i%j == 0)
                        {
                            right = false;
                        }
                    }
                    if (right)
                    {
                        Console.WriteLine(i.ToString());
                    }

                }
            }
            Console.ReadLine();
        }    
    }
}
