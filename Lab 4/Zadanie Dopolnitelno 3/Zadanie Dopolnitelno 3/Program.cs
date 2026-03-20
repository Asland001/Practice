using System;

namespace CurrencyTask
{
    class Program
    {
        static void Main()
        {
            double result;
            double amount = 690;
            
            ConvertCurrency(in amount, out result);
            Console.WriteLine($"Результат (фиксированный курс): {result}");
            
            ConvertCurrency(in amount, 1.2, out result);
            Console.WriteLine($"Результат (курс 1.2): {result}");

            Console.ReadKey();
        }

        //Метод с фиксированным курсом
        static void ConvertCurrency(in double amount, out double convertedAmount)
        {
            double fixedRate = 1.1;
            convertedAmount = amount * fixedRate;
        }

        //Перегруженный метод
        static void ConvertCurrency(in double amount, double exchangeRate, out double convertedAmount)
        {
            convertedAmount = amount * exchangeRate;
        }
    }
}   