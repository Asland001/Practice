using System;

namespace EvenSumDigits
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите двухзначное число: ");
            int number = int.Parse(Console.ReadLine());

            int tens = number / 10;
            int ones = number % 10;

            int sum = tens + ones;

            if (sum % 2 == 0)
            {
                Console.WriteLine("Сумма цифр чётная");
            }
            else
            {
                Console.WriteLine("Сумма цифр НЕчётная");
            }

            Console.ReadKey();
        }
    }
}