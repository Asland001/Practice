using System;

class Program
{
    static void Main()
    {
        double A = 0.0;
        double B = Math.PI / 2;
        int M = 20;

        double H = (B - A) / M;

        Console.WriteLine("Табулирование функции F(x) = sin(x) - cos(x)");
        Console.WriteLine($"Диапазон: [{A:F4}, {B:F4}], шаг H = {H:F6}, точек: {M+1}\n");
        Console.WriteLine("   №   |      x       |         F(x)");
        Console.WriteLine("-------|--------------|---------------------");

        double x = A;

        for (int i = 1; i <= M + 1; i++)
        {
            double y = Math.Sin(x) - Math.Cos(x);

            Console.WriteLine($"{i,4}   | {x,12:F6} | {y,19:F10}");

            x = x + H;
        }
    }
}