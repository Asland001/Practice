using System;

namespace SumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("b = ");
            double b = Convert.ToDouble(Console.ReadLine());

            double sum = a + b;

            Console.WriteLine("{0:F2} + {1:F2} = {2:F2}", a, b, sum);

            Console.ReadKey();
        }
    }
}