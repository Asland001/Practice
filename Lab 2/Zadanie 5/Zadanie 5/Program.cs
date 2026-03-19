using System;

class Program
{
    static void Main()
    {
        int[][] jagged = new int[4][]
        {
            new int[] { 7, 2, 9, 4, 1 },
            new int[] { 4, 9, 1, 7, 2 },
            new int[] { 2, 1, 7, 9, 4 },
            new int[] { 9, 4, 2, 1, 7 }
        };
        

        Console.WriteLine("Ступенчатый массив:");
        PrintJagged(jagged);
        
        bool allArePermutations = AreAllRowsPermutations(jagged);

        Console.WriteLine();
        if (allArePermutations)
        {
            Console.WriteLine("→ ДА, все строки являются перестановками друг друга");
        }
        else
        {
            Console.WriteLine("→ НЕТ, не все строки являются перестановками друг друга");
        }
    }


    static bool AreAllRowsPermutations(int[][] arr)
    {
        if (arr == null || arr.Length == 0)
            return true;
        
        int len = arr[0].Length;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == null || arr[i].Length != len)
            {
                Console.WriteLine($"Строка {i} имеет другую длину → невозможно быть перестановкой");
                return false;
            }
        }
        
        int[] reference = (int[])arr[0].Clone();
        Array.Sort(reference);
        
        for (int i = 1; i < arr.Length; i++)
        {
            int[] sorted = (int[])arr[i].Clone();
            Array.Sort(sorted);

            for (int j = 0; j < len; j++)
            {
                if (sorted[j] != reference[j])
                    return false;
            }
        }

        return true;
    }


    static void PrintJagged(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Строка {i + 1,2}: ");
            if (arr[i] == null)
            {
                Console.WriteLine("(null)");
                continue;
            }
            Console.WriteLine(string.Join(" ", arr[i]));
        }
    }
}