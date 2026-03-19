using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine() ?? "";

        string firstNumberWord = FindFirstNumericWord(text);

        if (string.IsNullOrEmpty(firstNumberWord))
        {
            Console.WriteLine("В строке нет слова, состоящего только из цифр");
        }
        else
        {
            Console.WriteLine($"Первое числовое слово: → {firstNumberWord} ←");
        }
    }

    static string FindFirstNumericWord(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
            return "";

        string[] words = s.Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', ';', ':', '!', '?' },
            StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (IsNumeric(word))
                return word;
        }

        return "";
    }

    static bool IsNumeric(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;

        foreach (char c in word)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }
}