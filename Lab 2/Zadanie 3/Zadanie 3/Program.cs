using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Console.Write("Введите размер матрицы N (N < 10): ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N < 1 || N >= 10)
        {
            Console.WriteLine("Ошибка: N должно быть целым числом от 1 до 9");
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
            Console.WriteLine("Ошибка: b должно быть >= a");
            return;
        }

        //Создание и заполнение матрицы
        int[,] matrix = new int[N, N];
        Random rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rnd.Next(a, b + 1);  // [a, b] включительно
            }
        }
        
        Console.WriteLine($"\nИсходная матрица {N}×{N}:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write($"{matrix[i, j],6}");
            }
            Console.WriteLine();
        }

        //Ввод G и поиск среднего арифметического элементов > G
        Console.Write("\nВведите число G: ");
        if (!int.TryParse(Console.ReadLine(), out int G))
        {
            Console.WriteLine("Ошибка ввода G");
            return;
        }

        double sum = 0;
        int count = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] > G)
                {
                    sum += matrix[i, j];
                    count++;
                }
            }
        }

        Console.WriteLine($"\nЭлементы, большие G ({G}): найдено {count} шт.");

        if (count > 0)
        {
            double average = sum / count;
            Console.WriteLine($"Среднее арифметическое элементов > G = {average:F3}");
        }
        else
        {
            Console.WriteLine("Нет элементов, больших G → среднее не определено");
        }

        //Ввод номера строки k и подсчёт чётных элементов
        Console.Write($"\nВведите номер строки k (от 1 до {N}): ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k < 1 || k > N)
        {
            Console.WriteLine($"Ошибка: номер строки должен быть от 1 до {N}");
            return;
        }

        int evenCount = 0;
        for (int j = 0; j < N; j++)
        {
            if (matrix[k - 1, j] % 2 == 0)
            {
                evenCount++;
            }
        }

        Console.WriteLine($"\nВ строке №{k} найдено {evenCount} чётных элементов.");
        Console.Write("Элементы строки: ");
        for (int j = 0; j < N; j++)
        {
            Console.Write($"{matrix[k - 1, j],4}");
        }
        Console.WriteLine();
    }
}