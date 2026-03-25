using System;
using System.Collections.Generic;

namespace InventoryAppZadanie3
{
    //Пользовательское исключение
    public class OutOfStockException : Exception
    {
        public OutOfStockException() { }

        public OutOfStockException(string message)
            : base(message) { }

        public OutOfStockException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    //Класс склада
    public class Inventory
    {
        private readonly List<string> _items = new List<string>
        {
            "Ноутбук",
            "Мышь",
            "Клавиатура",
            "Монитор",
            "Принтер",
            "Сканер",
            "Веб-камера",
            "Наушники",
            "Колонки",
            "Флешка",
            "Жёсткий диск",
            "SSD накопитель",
            "Роутер",
            "Смартфон",
            "Планшет"
        };

        public void CheckStock(string item)
        {
            if (!_items.Contains(item))
            {
                throw new OutOfStockException($"Товар '{item}' отсутствует на складе");
            }

            Console.WriteLine($"Товар '{item}' есть в наличии");
        }
    }

    class Program
    {
        static void Main()
        {
            Inventory inventory = new Inventory();

            Console.Write("Введите название товара: ");
            string item = Console.ReadLine();

            try
            {
                inventory.CheckStock(item);
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}