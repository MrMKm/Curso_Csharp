using System;

namespace LambdaExpressions
{
    class DelegateCalculator
    {
        public delegate double SelfOperator(double x);
        public delegate double Operator(double x, double y);

        public static void Operate(double num, double num2)
        {
            SelfOperator square = new SelfOperator(x => x * x);
            Console.WriteLine("Potencia: " + square(num));

            Operator addition = new Operator((x, y) => x + y);
            Console.WriteLine("Suma: " + addition(num, num2));

            Operator substract = new Operator((x, y) => x - y);
            Console.WriteLine("Resta: " + substract(num, num2));

            Operator product = new Operator((x, y) => x * y);
            Console.WriteLine("Multiplicación: " + product(num, num2));

            Operator division = new Operator((x, y) => x / y);
            Console.WriteLine("División: " + division(num, num2));

            SelfOperator sin = new SelfOperator(x => Math.Sin(x));
            Console.WriteLine("Seno: " + sin(num));

            SelfOperator cos = new SelfOperator(x => Math.Cos(x));
            Console.WriteLine("Coseno: " + cos(num));
        }
    }

    class FunctionCalculator
    {
        public static void Operate(double x, double y)
        {
            Func<double, double> square = x => x * x;
            Console.WriteLine("Potencia: " + square(x));

            Func<double, double, double> addition = (x, y) => x + y;
            Console.WriteLine("Suma: " + addition(x, y));

            Func<double, double, double> substract = (x, y) => x - y;
            Console.WriteLine("Resta: " + substract(x, y));

            Func<double, double, double> product = (x, y) => x * y;
            Console.WriteLine("Multiplicación: " + product(x, y));

            Func<double, double, double> division = (x, y) => x / y;
            Console.WriteLine("División: " + division(x, y));

            Func<double, double> sin = x => Math.Sin(x);
            Console.WriteLine("Seno: " + sin(x));

            Func<double, double> cos = x => Math.Cos(x);
            Console.WriteLine("Coseno: " + cos(x));
        }
    }

    class ActionCalculator
    {
        public static void Operate(double x, double y)
        {
            Action<double, double> addition = (x, y) =>
            {
                Console.WriteLine(x + y);
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert two numbers: ");
            var inputX = Console.ReadLine();
            var inputY = Console.ReadLine();
            Console.WriteLine();

            if (Double.TryParse(inputX, out double x) && Double.TryParse(inputY, out double y))
                //DelegateCalculator.Operate(x, y);
                //FunctionCalculator.Operate(x, y);
                //ActionCalculator.Operate(x, y);

            else
                Console.WriteLine("Invalid number");
        }
    }
}
