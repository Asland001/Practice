using System;
using System.IO;
using System.Text.Json;

namespace SerializationAppZadanie
{
    //Обобщённый интерфейс
    public interface ISerializer<T>
    {
        string Serialize(T item);
        T Deserialize(string data);
    }

    //Реализация
    public class JsonSerializer<T> : ISerializer<T>
    {
        public string Serialize(T item)
        {
            return JsonSerializer.Serialize(item);
        }

        public T Deserialize(string data)
        {
            return JsonSerializer.Deserialize<T>(data);
        }
    }

    //Класс-хранилище (репозиторий)
    public class SerializerRepository<T>
    {
        private readonly ISerializer<T> _serializer;

        public SerializerRepository(ISerializer<T> serializer)
        {
            _serializer = serializer;
        }

        public string ConvertToString(T item)
        {
            return _serializer.Serialize(item);
        }

        public T ConvertFromString(string data)
        {
            return _serializer.Deserialize(data);
        }
    }

    //Бизнес-логика
    public class SerializerManager<T>
    {
        private readonly SerializerRepository<T> _repository;

        public SerializerManager(SerializerRepository<T> repository)
        {
            _repository = repository;
        }

        public void SaveToFile(T item, string filename)
        {
            string data = _repository.ConvertToString(item);
            File.WriteAllText(filename, data);
            Console.WriteLine("Объект сохранён в файл");
        }

        public T LoadFromFile(string filename)
        {
            string data = File.ReadAllText(filename);
            return _repository.ConvertFromString(data);
        }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            ISerializer<Person> serializer = new JsonSerializer<Person>();
            SerializerRepository<Person> repository = new SerializerRepository<Person>(serializer);
            SerializerManager<Person> manager = new SerializerManager<Person>(repository);
            
            Person person = new Person { Name = "Artem", Age = 19 };

            manager.SaveToFile(person, "person.json");

            Person loaded = manager.LoadFromFile("person.json");

            Console.WriteLine($"Загружено: {loaded.Name}, {loaded.Age}");
        }
    }
}