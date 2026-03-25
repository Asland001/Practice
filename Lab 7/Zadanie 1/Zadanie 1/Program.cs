using System;

namespace EmailValidationAppZadanie
{
    //Пользовательское исключение
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException()
        {
        }
        
        public InvalidEmailFormatException(string message)
            : base(message)
        {
        }
        
        public InvalidEmailFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    //Класс для проверки email
    public class EmailValidator
    {
        public void ValidateEmail(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || !email.Contains("@") || email.Contains(".."))
                {
                    throw new InvalidEmailFormatException("Некорректный формат email");
                }

                Console.WriteLine("Email корректный");
            }
            catch (Exception ex)
            {
                throw new InvalidEmailFormatException("Ошибка при проверке email", ex);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            EmailValidator validator = new EmailValidator();

            Console.Write("Введите email: ");
            string email = Console.ReadLine();

            try
            {
                validator.ValidateEmail(email);
            }
            catch (InvalidEmailFormatException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Внутренняя ошибка: {ex.InnerException.Message}");
                }
            }
        }
    }
}