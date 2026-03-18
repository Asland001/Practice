using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите текущий курс доллара (рублей за 1 USD): ");
        double rate;
        
        while (!double.TryParse(Console.ReadLine(), out rate) || rate <= 0)
        {
            Console.Write("Ошибка. Введите положительное число: ");
        }

        Console.WriteLine("\nДоллары → Бел.рубли (курс = {0:F2})\n", rate);
        Console.WriteLine("  USD     |     BYN  ");
        Console.WriteLine("----------|----------");

        //Цикл while
        Console.WriteLine("\nВариант 1 — while");
        int dollars = 5;
        while (dollars <= 500)
        {
            double rub = dollars * rate;
            Console.WriteLine("{0,6}    | {1,9:F2}", dollars, rub);
            dollars += 5;
        }

        //Цикл do-while
        Console.WriteLine("\nВариант 2 — do-while");
        dollars = 5;
        do
        {
            double rub = dollars * rate;
            Console.WriteLine("{0,6}    | {1,9:F2}", dollars, rub);
            dollars += 5;
        } while (dollars <= 500);

        //Цикл for
        Console.WriteLine("\nВариант 3 — for");
        for (dollars = 5; dollars <= 500; dollars += 5)
        {
            double rub = dollars * rate;
            Console.WriteLine("{0,6}    | {1,9:F2}", dollars, rub);
        }
    }
}