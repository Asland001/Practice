using System;

namespace FormulaCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            double z1 = ((a + 2) / Math.Sqrt(2 * a)
                         - a / Math.Sqrt(2 * a + 2)
                         + 2 / (a - Math.Sqrt(2 * a)))
                * (Math.Sqrt(a) - Math.Sqrt(2)) / (a + 2);

            double z2 = 1 / (Math.Sqrt(a) + Math.Sqrt(2));

            Console.WriteLine($"z1 = {z1}");
            Console.WriteLine($"z2 = {z2}");
        }
    }
}