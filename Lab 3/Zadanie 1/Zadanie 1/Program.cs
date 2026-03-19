using System;

namespace ClassZadanie
{
    class A
    {
        private int a;
        private int b;
        
        public A(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        //sin(b) + 4/(2a)
        public double CalculateExpression()
        {
            return Math.Sin(b) + 4.0 / (2 * a);
        }

        //(a + b)^2
        public int SquareSum()
        {
            return (a + b) * (a + b);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите a: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Введите b: ");
            int b = int.Parse(Console.ReadLine());

            A obj = new A(a, b);

            Console.WriteLine($"sin(b) + 4/(2a) = {obj.CalculateExpression():F4}");
            Console.WriteLine($"(a + b)^2 = {obj.SquareSum()}");

            Console.ReadKey();
        }
    }
}