using System;

namespace FigureCalculator
{
    class DelegateCalculator
    {
        public delegate double SelfOperator(double x);
        public delegate double Operator(double x, double y);

        public static Tuple<double, double> Operate(int opc, double x, double y)
        {
            SelfOperator p_Square = new SelfOperator(x => x * 4);
            SelfOperator a_Square = new SelfOperator(x => x * x);

            Operator p_Rectangle = new Operator((x, y) => (x * 2) + (y * 2));
            Operator a_Rectangle = new Operator((x, y) => x * y);

            Operator p_Triangle = new Operator((x, y) => x * 3);
            Operator a_Triangle = new Operator((x, y) => (x * y) / 2);

            SelfOperator p_Circle = new SelfOperator(x => (2 * Math.PI) * x);
            SelfOperator a_Circle = new SelfOperator(x =>  Math.Pow((Math.PI * x),2));

            switch (opc)
            {
                case 1:
                    return Tuple.Create(p_Square(x), a_Square(x));

                case 2:
                    return Tuple.Create(p_Rectangle(x, y), a_Rectangle(x, y));

                case 3:
                    return Tuple.Create(p_Triangle(x, y), a_Triangle(x, y));

                case 4:
                    return Tuple.Create(p_Circle(x), a_Circle(x));
            }

            return Tuple.Create(double.NaN, double.NaN);
        }
    }

    class FunctionCalculator
    {
        public static Tuple<double, double> Operate(int opc, double x, double y)
        {
            Func<double, double> p_Square = x => x * 4;
            Func<double, double> a_Square = x => x * x;

            Func<double, double, double> p_Rectangle = (x,y) => (x * 2) + (y * 2);
            Func<double, double, double> a_Rectangle = (x, y) => x * y;

            Func<double, double, double> p_Triangle = (x, y) => x * 3;
            Func<double, double, double> a_Triangle = (x, y) => (x * y) / 2;

            Func<double, double> p_Circle = x => (2 * Math.PI) * x;
            Func<double, double> a_Circle = x => Math.Pow((Math.PI * x), 2);

            switch (opc)
            {
                case 1:
                    return Tuple.Create(p_Square(x), a_Square(x));

                case 2:
                    return Tuple.Create(p_Rectangle(x, y), a_Rectangle(x, y));

                case 3:
                    return Tuple.Create(p_Triangle(x, y), a_Triangle(x, y));

                case 4:
                    return Tuple.Create(p_Circle(x), a_Circle(x));
            }

            return Tuple.Create(double.NaN, double.NaN);
        }
    }

    class Program
    {
        static int FiguresMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Choose an searching option:\n" +
                "1. Perimeter\n" +
                "2. Area\n\n" +
                "Type your option: ");

            int opc = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine();

            return opc;
        }

        static void Main(string[] args)
        {
            Console.Write("Choose an searching option:\n" +
                "1. Square\n" +
                "2. Rectangle\n" +
                "3. Triangle\n" +
                "4. Circle\n\n" +
                "Type your option: ");

            int opc = Convert.ToInt32(Console.ReadLine());
            double side = 0, height = 0, Radius = 0, _base = 0;
            var results = FunctionCalculator.Operate(0, 0, 0);

            switch (opc)
            {
                case 1:
                    Console.WriteLine("Side: ");
                    side = Convert.ToInt32(Console.ReadLine());

                    results = FunctionCalculator.Operate(opc, side, (double)0);

                    if (FiguresMenu() == 1)
                        Console.WriteLine("Square Perimeter: " + results.Item1);
                    else
                        Console.WriteLine("Square Area: " + results.Item2);

                    break;

                case 2:
                    Console.WriteLine("Base: ");
                    _base = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Height: ");
                    height = Convert.ToInt32(Console.ReadLine());

                    results = FunctionCalculator.Operate(2, _base, height);

                    if (FiguresMenu() == 1)
                        Console.WriteLine("Rectangle Perimeter: " + results.Item1);
                    else
                        Console.WriteLine("Rectangle Area: " + results.Item2);

                    break;

                case 3:
                    Console.WriteLine("Base: ");
                    _base = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Height: ");
                    height = Convert.ToInt32(Console.ReadLine());

                    results = FunctionCalculator.Operate(3, _base, height);

                    if (FiguresMenu() == 1)
                        Console.WriteLine("Triangle Perimeter: " + results.Item1);
                    else
                        Console.WriteLine("Triangle Area: " + results.Item2);

                    break;

                case 4:
                    Console.WriteLine("Radius: ");
                    Radius = Convert.ToInt32(Console.ReadLine());

                    results = FunctionCalculator.Operate(4, Radius, 0);

                    if (FiguresMenu() == 1)
                        Console.WriteLine("Circle Perimeter: " + results.Item1);
                    else
                        Console.WriteLine("Circle Area: " + results.Item2);

                    break;
            }
        }
    }
}
