using System;
using System.IO;

namespace FileDelegateAppZadanie
{
    //Пользовательский делегат
    public delegate void FileHandler(string path);

    //Класс для чтения файла
    public class FileReader
    {
        public void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Файл не найден");
            }
        }
    }

    //Класс для записи в файл
    public class FileWriter
    {
        public void WriteFile(string path)
        {
            File.WriteAllText(path, "Fireflies\nТрек – Owl City 2009 г.");
            Console.WriteLine("Данные записаны в файл");
        }
    }

    class Program
    {
        static void Main()
        {
            string path = "test.txt";

            FileReader reader = new FileReader();
            FileWriter writer = new FileWriter();
            
            FileHandler handler;

            handler = writer.WriteFile;
            handler(path);

            Console.WriteLine();
            
            handler = reader.ReadFile;
            handler(path);
        }
    }
}