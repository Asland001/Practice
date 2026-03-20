using System;

class Program
{
    static void Main(string[] args)
    {
        int[] test1 = { 5, 3, 9, 1 };
        int[] test2 = { 7, 2, 8, 4, 0, -1, 5 };
        int[] test3 = { 42 };
        int[] test4 = { -10, -20, -5, -15 };

        Console.WriteLine("Тест 1: " + string.Join(", ", test1) + " → min = " + FindMin(test1));
        Console.WriteLine("Тест 2: " + string.Join(", ", test2) + " → min = " + FindMin(test2));
        Console.WriteLine("Тест 3: " + string.Join(", ", test3) + " → min = " + FindMin(test3));
        Console.WriteLine("Тест 4: " + string.Join(", ", test4) + " → min = " + FindMin(test4));
    }
    
    public static int FindMin(int[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr), "Массив не может быть null");

        if (arr.Length == 0)
            throw new ArgumentException("Массив не может быть пустым", nameof(arr));
        
        return FindMinRecursive(arr, 0, arr[0]);
    }
    
    private static int FindMinRecursive(int[] arr, int index, int currentMin)
    {
        if (index == arr.Length)
        {
            return currentMin;
        }
        
        int newMin = Math.Min(currentMin, arr[index]);
        
        return FindMinRecursive(arr, index + 1, newMin);
    }
}