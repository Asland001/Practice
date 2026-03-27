using System;
using System.Collections.Generic;

namespace CacheAppZadanie
{
    //Интерфейс стратегии
    public interface ICacheStrategy
    {
        void Add(string key, string value);
        string Get(string key);
    }

    //Конкретные стратегии
    
    public class InMemoryCache : ICacheStrategy
    {
        private Dictionary<string, string> _cache = new Dictionary<string, string>();

        public void Add(string key, string value)
        {
            _cache[key] = value;
            Console.WriteLine("Сохранено в InMemoryCache");
        }

        public string Get(string key)
        {
            return _cache.ContainsKey(key) ? _cache[key] : "Нет данных";
        }
    }

    //Имитация распределённого кеша
    public class DistributedCache : ICacheStrategy
    {
        public void Add(string key, string value)
        {
            Console.WriteLine("Сохранено в DistributedCache (удалённо)");
        }

        public string Get(string key)
        {
            return $"Получено из DistributedCache: {key}";
        }
    }
    
    public class NoCache : ICacheStrategy
    {
        public void Add(string key, string value)
        {
            Console.WriteLine("Кеш отключён");
        }

        public string Get(string key)
        {
            return "Кеш отключён";
        }
    }

    //Контекст
    public class CacheManager
    {
        private ICacheStrategy _strategy;

        public CacheManager(ICacheStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public void SetStrategy(ICacheStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Add(string key, string value)
        {
            _strategy.Add(key, value);
        }

        public void Get(string key)
        {
            Console.WriteLine(_strategy.Get(key));
        }
    }

    class Program
    {
        static void Main()
        {
            CacheManager manager = new CacheManager(new InMemoryCache());

            manager.Add("user1", "Alan");
            manager.Get("user1");

            Console.WriteLine();
            
            manager.SetStrategy(new DistributedCache());
            manager.Add("user2", "Alex");
            manager.Get("user2");

            Console.WriteLine();
            
            manager.SetStrategy(new NoCache());
            manager.Add("user3", "Miro");
            manager.Get("user3");
        }
    }
}