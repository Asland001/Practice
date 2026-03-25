using System;

namespace XmlAppZadanie
{
    //Пользовательское исключение
    public class DeserializationException : Exception
    {
        public DeserializationException() { }

        public DeserializationException(string message)
            : base(message) { }

        public DeserializationException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    //"Сторонний" класс
    public class XmlDeserializer
    {
        public void Deserialize(string xml)
        {
            // Имитация ошибки XML
            if (string.IsNullOrWhiteSpace(xml) || !xml.StartsWith("<") || !xml.EndsWith(">"))
            {
                throw new InvalidOperationException("Неверный формат XML");
            }

            Console.WriteLine("XML успешно десериализован");
        }
    }

    //Класс-обработчик
    public class XmlProcessor
    {
        private readonly XmlDeserializer _deserializer = new XmlDeserializer();

        public void Process(string xml)
        {
            try
            {
                _deserializer.Deserialize(xml);
            }
            catch (Exception ex)
            {
                Console.WriteLine("=== Лог ошибки ===");
                Console.WriteLine($"Сообщение: {ex.Message}");
                Console.WriteLine($"Тип: {ex.GetType()}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("=== Внутреннее исключение ===");
                    Console.WriteLine($"Сообщение: {ex.InnerException.Message}");
                    Console.WriteLine($"Тип: {ex.InnerException.GetType()}");
                    Console.WriteLine($"StackTrace: {ex.InnerException.StackTrace}");
                }
                
                throw new DeserializationException("Ошибка при десериализации Xml", ex);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            XmlProcessor processor = new XmlProcessor();

            string badXml = "invalid xml";

            try
            {
                processor.Process(badXml);
            }
            catch (DeserializationException ex)
            {
                Console.WriteLine("\n=== Обработка в Main ===");
                Console.WriteLine($"Ошибка: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Внутренняя ошибка: {ex.InnerException.Message}");
                }
            }
        }
    }
}