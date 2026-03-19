using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.Write("Введите размер квадратной матрицы N (N ≥ 2): ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N < 2)
        {
            Console.WriteLine("Ошибка: N должно быть целым числом ≥ 2");
            return;
        }
        
        Console.Write("Введите начало диапазона a: ");
        if (!int.TryParse(Console.ReadLine(), out int a))
        {
            Console.WriteLine("Ошибка ввода a");
            return;
        }

        Console.Write("Введите конец диапазона b: ");
        if (!int.TryParse(Console.ReadLine(), out int b) || b < a)
        {
            Console.WriteLine("Ошибка: b должно быть ≥ a");
            return;
        }
        
        int[,] matrix = new int[N, N];
        Random rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rnd.Next(a, b + 1);
            }
        }
        
        Console.WriteLine($"\nСгенерированная матрица {N}×{N}:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"{matrix[i, j],6}");
            }
            Console.WriteLine();
        }

        //Вычисление суммы первой строки
        long sumFirst = 0;
        for (int j = 0; j < N; j++)
        {
            sumFirst += matrix[0, j];
        }

        //Вычисление суммы предпоследней строки
        long sumPenultimate = 0;
        for (int j = 0; j < N; j++)
        {
            sumPenultimate += matrix[N - 2, j];
        }
        
        Console.WriteLine($"\nСумма элементов первой строки     (№1): {sumFirst}");
        Console.WriteLine($"Сумма элементов предпоследней строки (№{N-1}): {sumPenultimate}");

        Console.Write("\nРезультат сравнения: ");

        if (sumFirst > sumPenultimate)
        {
            Console.WriteLine("Сумма в первой строке больше");
        }
        else if (sumPenultimate > sumFirst)
        {
            Console.WriteLine("Сумма в предпоследней строке больше");
        }
        else
        {
            Console.WriteLine("Суммы в первой и предпоследней строках **равны**");
        }
        
        Console.WriteLine("\nПервая строка:");
        for (int j = 0; j < N; j++)
            Console.Write($"{matrix[0, j],6}");
        Console.WriteLine($"  → сумма = {sumFirst}");

        Console.WriteLine("\nПредпоследняя строка:");
        for (int j = 0; j < N; j++)
            Console.Write($"{matrix[N-2, j],6}");
        Console.WriteLine($"  → сумма = {sumPenultimate}");
    }
}