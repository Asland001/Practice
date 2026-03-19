using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string s = Console.ReadLine() ?? "";

        int maxLength = FindLongestSubstringLength(s);

        Console.WriteLine($"Самая длинная подстрока без повторяющихся символов имеет длину: {maxLength}");
    }

    static int FindLongestSubstringLength(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;

        int maxLen = 1;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                string sub = s.Substring(i, j - i + 1);
                if (HasUniqueChars(sub))
                {
                    maxLen = Math.Max(maxLen, j - i + 1);
                }
                else
                {
                    break;
                }
            }
        }

        return maxLen;
    }

    static bool HasUniqueChars(string str)
    {
        var seen = new HashSet<char>();
        foreach (char c in str)
        {
            if (!seen.Add(c)) return false;
        }
        return true;
    }
}