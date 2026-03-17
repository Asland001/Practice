using System;

namespace Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите величину временного интервала (в минутах):");

            int totalMinutes = int.Parse(Console.ReadLine());

            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            Console.WriteLine("{0} минут — это {1}ч. {2} мин.", totalMinutes, hours, minutes);
        }
    }
}