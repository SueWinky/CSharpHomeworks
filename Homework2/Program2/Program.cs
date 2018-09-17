using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请您输入一组整数，用逗号隔开：");

            String str = Console.ReadLine();
            String[] s = str.Split(',');
            int[] b = new int[s.Length];
            for (int i = 0; i < s.Length; ++i)
            {
                b[i] = int.Parse(s[i]);
            }
            Myclass c = new Myclass();

            c.get_number(b);
        }
    }
    class Myclass
    {
        public void get_number(params int[] a)
        {
            int i = 0;
            int max = a[0];
            int min = a[0];
            double sum = 0, ever = 0;
            for (i = 0; i < a.Length; i++)
            {
                if (max < a[i])
                    max = a[i];
                if (min > a[i])
                    min = a[i];
                sum += a[i];
            }
            ever = (sum) / (a.Length );
            Console.WriteLine("最大数：{0};", max);
            Console.WriteLine("最小数：{0};", min);
            Console.WriteLine("平均值：{0};", ever);
            Console.WriteLine("总和：{0}", sum);
            Console.ReadKey();
        }
    }
}
