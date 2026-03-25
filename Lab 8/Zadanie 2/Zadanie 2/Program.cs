using System;
using System.Collections.Generic;

namespace MyBagAppZadanie
{
    //Дженерик-коллекция
    public class MyBag<T>
    {
        private List<T> _items = new List<T>();
        
        public void Add(T item)
        {
            _items.Add(item);
        }
        
        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        //Поиск
        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        //Количество элементов
        public int Count()
        {
            return _items.Count;
        }
        
        public void ShowAll()
        {
            Console.WriteLine("Содержимое сумки:");
            foreach (T item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    //Класс-контроллер
    public class BagManager<T>
    {
        private MyBag<T> _bag = new MyBag<T>();

        public void AddItem(T item)
        {
            _bag.Add(item);
            Console.WriteLine($"Добавлен предмет: {item}");
        }

        public void RemoveItem(T item)
        {
            if (_bag.Remove(item))
            {
                Console.WriteLine($"Удалён предмет: {item}");
            }
            else
            {
                Console.WriteLine($"Предмет не найден: {item}");
            }
        }

        public void CheckItem(T item)
        {
            if (_bag.Contains(item))
            {
                Console.WriteLine($"Предмет есть в сумке: {item}");
            }
            else
            {
                Console.WriteLine($"Предмет отсутствует: {item}");
            }
        }

        public void ShowInventory()
        {
            _bag.ShowAll();
        }
    }

    class Program
    {
        static void Main()
        {
            BagManager<string> manager = new BagManager<string>();
            
            manager.AddItem("Меч");
            manager.AddItem("Зелье");
            manager.AddItem("Меч");

            Console.WriteLine();
            
            manager.CheckItem("Меч");

            Console.WriteLine();

            manager.ShowInventory();

            Console.WriteLine();
            
            manager.RemoveItem("Меч");

            Console.WriteLine();

            manager.ShowInventory();
        }
    }
}