using System;

namespace CircleZadanie
{
    class Circle
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите радиус: ");
            double r = double.Parse(Console.ReadLine());

            Circle circle = new Circle(r);

            Console.WriteLine($"Длина окружности: {circle.GetCircumference():F2}");
            Console.WriteLine($"Площадь круга: {circle.GetArea():F2}");

            Console.ReadKey();
        }
    }
}