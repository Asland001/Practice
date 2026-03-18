using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Двузначные числа, равные утроенному произведению своих цифр:\n");

        int count = 0;

        for (int n = 10; n <= 99; n++)
        {
            int a = n / 10;
            int b = n % 10;

            if (n == 3 * a * b)
            {
                Console.WriteLine($"{n} = 3 * {a} * {b} = 3 * {a * b}");
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("Таких чисел не найдено.");
        }
        else
        {
            Console.WriteLine($"\nВсего найдено: {count} чисел");
        }
    }
}