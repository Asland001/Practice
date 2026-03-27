using System;
using System.Collections.Generic;

namespace GameAppZadanie
{
    public class GameResourceManager
    {
        //Хранилище ресурсов
        private Dictionary<string, string> _resources = new Dictionary<string, string>();
        
        private static GameResourceManager _instance;
        
        private GameResourceManager()
        {
        }
        
        public static GameResourceManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameResourceManager();
            }

            return _instance;
        }

        //Загрузка ресурса
        public void LoadResource(string name)
        {
            if (!_resources.ContainsKey(name))
            {
                _resources[name] = $"Ресурс {name} загружен";
                Console.WriteLine($"Загружен: {name}");
            }
            else
            {
                Console.WriteLine($"Ресурс уже загружен: {name}");
            }
        }

        //Получение ресурса
        public string GetResource(string name)
        {
            if (_resources.ContainsKey(name))
            {
                return _resources[name];
            }

            return "Ресурс не найден";
        }
    }

    class Program
    {
        static void Main()
        {
            GameResourceManager manager1 = GameResourceManager.GetInstance();
            GameResourceManager manager2 = GameResourceManager.GetInstance();
            
            Console.WriteLine($"Один объект? {manager1 == manager2}");
            
            manager1.LoadResource("Texture_Grass");
            manager1.LoadResource("Sound_Explosion");

            Console.WriteLine();

            Console.WriteLine(manager2.GetResource("Texture_Grass"));
            Console.WriteLine(manager2.GetResource("Sound_Explosion"));
        }
    }
}