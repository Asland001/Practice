using System;

namespace NumberPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите трехзначное число: ");
            int number = int.Parse(Console.ReadLine());

            int digit1 = number / 100;
            int digit2 = (number / 10) % 10;
            int digit3 = number % 10;

            int n1 = digit1 * 100 + digit2 * 10 + digit3;
            int n2 = digit1 * 100 + digit3 * 10 + digit2;
            int n3 = digit2 * 100 + digit1 * 10 + digit3;
            int n4 = digit2 * 100 + digit3 * 10 + digit1;
            int n5 = digit3 * 100 + digit1 * 10 + digit2;
            int n6 = digit3 * 100 + digit2 * 10 + digit1;

            Console.WriteLine("Полученные числа:");
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);

            Console.ReadKey();
        }
    }
}