using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите цену 1 кг конфет (A): ");
        int A = int.Parse(Console.ReadLine());
        
        if (A < 1 || A > 100)
        {
            Console.WriteLine("Ошибка: цена должна быть от 1 до 100");
            return;
        }

        Console.WriteLine("\nСтоимость конфет:");

        for (int kg = 1; kg <= 10; kg++)
        {
            int cost = kg * A;
            Console.WriteLine($"{kg,2} кг → {cost,4} руб.");
        }
    }
}