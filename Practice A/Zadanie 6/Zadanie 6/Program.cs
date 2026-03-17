using System;

namespace FunctionCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 2.7;

            double y = Math.Log(x + Math.Sqrt(x * x + 9))
                       - (x + 1) / Math.Atan(Math.Pow(x, 3));

            Console.WriteLine("x = {0:F2}", x);
            Console.WriteLine("y = {0:F4}", y);

            Console.ReadKey();
        }
    }
}