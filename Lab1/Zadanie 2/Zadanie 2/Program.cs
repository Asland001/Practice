using System;

namespace PalindromeZadanie
{
    class NumberChecker
    {
        public int Number { get; set; }

        public NumberChecker(int number)
        {
            Number = number;
        }

        public bool IsPalindrome()
        {
            int a = Number / 1000;
            int b = (Number / 100) % 10;
            int c = (Number / 10) % 10;
            int d = Number % 10;

            return a == d && b == c;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Введите четырехзначное число: ");
            int num = int.Parse(Console.ReadLine());

            NumberChecker checker = new NumberChecker(num);

            if (checker.IsPalindrome())
                Console.WriteLine("Число читается одинаково (палиндром)");
            else
                Console.WriteLine("Число НЕ является палиндромом");

            Console.ReadKey();
        }
    }
}