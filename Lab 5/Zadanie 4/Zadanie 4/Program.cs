using System;

namespace LoggingAppZadanie
{
    //Интерфейс ошибок
    public interface IErrorLogger
    {
        void Log(string message);
    }

    //Интерфейс событий
    public interface IEventLogger
    {
        void Log(string message);
    }

    //Класс, реализующий оба интерфейса
    public class Logger : IErrorLogger, IEventLogger
    {
        void IErrorLogger.Log(string message)
        {
            Console.WriteLine($"[ERROR]: {message}");
        }
        
        void IEventLogger.Log(string message)
        {
            Console.WriteLine($"[EVENT]: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            Logger logger = new Logger();

            //Доступ через интерфейс IErrorLogger
            IErrorLogger errorLogger = logger;
            errorLogger.Log("Ошибка подключения к базе данных");
            
            IEventLogger eventLogger = logger;
            eventLogger.Log("Пользователь вошёл в систему");
        }
    }
}