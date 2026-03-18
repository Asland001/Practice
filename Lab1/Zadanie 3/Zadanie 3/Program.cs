using System;

namespace HarmonicSum
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите N (1..20): ");
            int n = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += 1.0 / i;
            }

            Console.WriteLine($"Сумма = {sum:F4}");

            Console.ReadKey();
        }
    }
}