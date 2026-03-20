using System;

namespace LogZadanie 
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(LogMessage("Сервер запущен"));
            Console.WriteLine(LogMessage("Произошла ошибка", "404"));

            Console.ReadKey();
        }

        //Обычное сообщение
        static string LogMessage(string message)
        {
            return message;
        }

        //Сообщение с ошибкой
        static string LogMessage(string message, string errorCode)
        {
            return $"{message}, Code: {errorCode}";
        }
    }
}