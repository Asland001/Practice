using System;

namespace MotionCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начальную скорость v0: ");
            double initialVelocity = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите ускорение a: ");
            double acceleration = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите время t: ");
            double time = Convert.ToDouble(Console.ReadLine());

            double velocity = initialVelocity + acceleration * time;
            double distance = initialVelocity * time + (acceleration * time * time) / 2;

            Console.WriteLine("Скорость v = {0:F2}", velocity);
            Console.WriteLine("Расстояние S = {0:F2}", distance);

            Console.ReadKey();
        }
    }
}