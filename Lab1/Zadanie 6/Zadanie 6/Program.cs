using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер дня месяца (1–31): ");
        int day = int.Parse(Console.ReadLine());

        if (day < 1 || day > 31)
        {
            Console.WriteLine("Ошибка: день должен быть от 1 до 31");
            return;
        }

        int daysInMonth;

        if (day <= 28)
        {
            daysInMonth = 31;
        }
        else if (day <= 30)
        {
            if (day == 29)
            {
                Console.WriteLine("29 февраля — только в високосный год. Считаем февраль 28 дней.");
                daysInMonth = 28;
            }
            else
            {
                daysInMonth = 30;
            }
        }
        else
        {
            daysInMonth = 31;
        }

        int daysLeft = daysInMonth - day;
        Console.WriteLine($"До конца месяца осталось {daysLeft} дней.");
    }
}