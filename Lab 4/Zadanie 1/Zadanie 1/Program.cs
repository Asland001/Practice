using System;

namespace WordCountZadanie
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            int count = CountWords(input);

            Console.WriteLine($"Количество слов: {count}");

            Console.ReadKey();
        }
        
        static int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}