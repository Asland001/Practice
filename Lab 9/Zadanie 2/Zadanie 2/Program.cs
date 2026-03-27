using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomerAppZadanie
{
    //Модельный класс
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    //Класс записи
    public class CustomerFileWriter
    {
        private readonly string _filePath = "file.data";

        public void WriteUniqueCustomers(List<Customer> customers)
        {
            var uniqueCustomers = customers
                .GroupBy(c => c.Id)
                .Select(g => g.First())
                .ToList();

            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var customer in uniqueCustomers)
                {
                    writer.WriteLine($"{customer.Id};{customer.Name}");
                }
            }

            Console.WriteLine("Уникальные клиенты записаны в файл");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer(1, "Алан"),
                new Customer(2, "Алекс"),
                new Customer(1, "Алан"),
                new Customer(3, "Рапунцель"),
                new Customer(2, "Алекс")
            };

            CustomerFileWriter writer = new CustomerFileWriter();

            writer.WriteUniqueCustomers(customers);
        }
    }
}