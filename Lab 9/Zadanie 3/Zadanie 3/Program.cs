using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomerReadAppZadanie
{
    //Модель
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }

    //Чтение файла
    public class CustomerFileReader
    {
        private readonly string _filePath = "file.data";

        public List<Customer> ReadCustomers()
        {
            List<Customer> customers = new List<Customer>();

            if (!File.Exists(_filePath))
            {
                Console.WriteLine("Файл не найден");
                return customers;
            }

            string[] lines = File.ReadAllLines(_filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int id))
                {
                    string name = parts[1];
                    customers.Add(new Customer(id, name));
                }
            }

            return customers;
        }
    }

    //Обработка данных
    public class CustomerProcessor
    {
        public List<Customer> FindDuplicates(List<Customer> customers)
        {
            return customers
                .GroupBy(c => c.Id)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .ToList();
        }
        
        public void ShowAll(List<Customer> customers)
        {
            Console.WriteLine("Все клиенты:");
            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            CustomerFileReader reader = new CustomerFileReader();
            CustomerProcessor processor = new CustomerProcessor();
            
            List<Customer> customers = reader.ReadCustomers();
            
            processor.ShowAll(customers);

            Console.WriteLine();

            var duplicates = processor.FindDuplicates(customers);

            Console.WriteLine("Дубликаты:");
            foreach (var c in duplicates)
            {
                Console.WriteLine(c);
            }
        }
    }
}