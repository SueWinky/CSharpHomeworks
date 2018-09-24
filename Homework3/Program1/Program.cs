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
            var test1 = ShapeFactory.GetResult("Round");
            var test2 = ShapeFactory.GetResult("Square");
            var test3 = ShapeFactory.GetResult("Triangle");
            var test4 = ShapeFactory.GetResult("Rectangle");
            test1.Numradius = 10;
            test2.Numside = 4;
            test3.Numbase = 5;
            test3.Numheight = 3;
            test4.Numlength = 8;
            test4.Numwidth = 3;
            Console.WriteLine("圆面积为：" + test1.Result());
            Console.WriteLine("正方形面积为：" + test2.Result());
            Console.WriteLine("三角形面积为：" + test3.Result());
            Console.WriteLine("长方形面积为：" + test4.Result());
        }
    }
    class Shape
    {
        public double Numradius;
        public double Numside;
        public double Numbase;
        public double Numheight;
        public double Numlength;
        public double Numwidth;
        public virtual double Result()
        {
            return 0;
        }
    }


    class ShapeRound : Shape
    {
        public override double Result()
        {
            return Numradius * Numradius * 3.14;
        }
    }

    class ShapeSquare : Shape
    {
        public override double Result()
        {
            return Numside * Numside;
        }
    }

    class ShapeTriangle : Shape
    {
        public override double Result()
        {
            return Numbase * Numheight * 0.5;
        }
    }

    class ShapeRectangle : Shape
    {
        public override double Result()
        {
            return Numwidth * Numlength;
        }
    }

    class ShapeFactory
    {
        public static Shape GetResult(string ope)
        {
            switch (ope)
            {
                case "Round":
                    return new ShapeRound();
                case "Square":
                    return new ShapeSquare();
                case "Triangle":
                    return new ShapeTriangle();
                case "Rectangle":
                    return new ShapeRectangle();
            }
            return null;
        }
    }
}

