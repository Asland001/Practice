using System;
using System.Text;

class Program
{
    static void Main()
    {
        string text = "LENOVO LEGION 5 PRO (RYZEN 7 5800H + RTX 3060) | ОБЗОР НОУТБУКА | МОЁ ЛИЧНОЕ МНЕНИЕ";
        string[] badWords = { "LENOVO", "RYZEN", "RTX", "ОБЗОР", "МОЁ" };

        string result = ReplaceBadWords(text, badWords);

        Console.WriteLine("Исходный текст:");
        Console.WriteLine(text);
        Console.WriteLine("\nПосле замены:");
        Console.WriteLine(result);
    }

    static string ReplaceBadWords(string text, string[] forbiddenWords)
    {
        if (string.IsNullOrEmpty(text) || forbiddenWords == null || forbiddenWords.Length == 0)
            return text;
        
        StringBuilder sb = new StringBuilder(text);
        
        var sortedWords = forbiddenWords
            .Where(w => !string.IsNullOrWhiteSpace(w))
            .OrderByDescending(w => w.Length)
            .ToArray();

        foreach (string word in sortedWords)
        {
            int pos = 0;
            while ((pos = sb.ToString().IndexOf(word, pos, StringComparison.OrdinalIgnoreCase)) >= 0)
            {
                bool isWholeWord = 
                    (pos == 0 || char.IsWhiteSpace(sb[pos - 1]) || char.IsPunctuation(sb[pos - 1])) &&
                    (pos + word.Length == sb.Length || char.IsWhiteSpace(sb[pos + word.Length]) || char.IsPunctuation(sb[pos + word.Length]));

                if (isWholeWord)
                {
                    sb.Remove(pos, word.Length);
                    sb.Insert(pos, "***");
                    pos += 3;
                }
                else
                {
                    pos += 1;
                }
            }
        }

        return sb.ToString();
    }
}