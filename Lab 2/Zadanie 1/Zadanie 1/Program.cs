using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Некорректный размер!");
            return;
        }

        int[] A = new int [n];

        Console.WriteLine($"Введите {n} целых чисел:");
        for (int i = 0; i < n; i++)
        {
            if (!int.TryParse(Console.ReadLine(), out A[i]))
            {
                Console.WriteLine("Ошибка ввода, введите целое цисло!");
                return;
            }
        }

        int count = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] < 0)
                count++;
        }

        Console.WriteLine($"\nМассив:[{string.Join(", ", A)}]");
        Console.WriteLine($"Количество отрицательных элементов: {count}");
    }
}    