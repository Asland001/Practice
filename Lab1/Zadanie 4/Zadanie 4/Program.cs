using System;

namespace PiecewiseFunction
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());

            double y;

            if (x < Math.PI)
            {
                y = x + 2 * x * Math.Sin(3 * x);
            }
            else if (x > Math.PI)
            {
                y = Math.Cos(x) + 2;
            }
            else
            {
                Console.WriteLine("x равно π, значение функции не определено");
                return;
            }

            Console.WriteLine($"y = {y:F4}");

            Console.ReadKey();
        }
    }
}