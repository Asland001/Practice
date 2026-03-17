using System;

namespace NumberPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите трехзначное число, в котором все цифры различны:");

            int number = int.Parse(Console.ReadLine());

            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            int num1 = digit1 * 100 + digit2 * 10 + digit3;
            int num2 = digit1 * 100 + digit3 * 10 + digit2;
            int num3 = digit2 * 100 + digit1 * 10 + digit3;
            int num4 = digit2 * 100 + digit3 * 10 + digit1;
            int num5 = digit3 * 100 + digit1 * 10 + digit2;
            int num6 = digit3 * 100 + digit2 * 10 + digit1;

            Console.WriteLine("Числа, полученные перестановкой цифр:");
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
        }
    }
}