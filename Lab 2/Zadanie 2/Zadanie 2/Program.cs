using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] a = new int[99];

        Random r = new Random();
        for (int i = 0; i < 99; i++) a[i] = r.Next(-50, 51);

        Console.WriteLine("Исходный массив:");
        Console.WriteLine(string.Join(" ", a));

        List<int> list = a.ToList();

        int min = list.Min();
        int max = list.Max();

        list.Remove(min);
        list.Remove(max);

        Console.WriteLine("\nПосле удаления одного минимального и одного максимального:");
        Console.WriteLine(string.Join(" ", list));
    }
}