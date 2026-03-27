using System;
using System.Collections.Generic;

namespace ObserverAppZadanie
{
    //Интерфейс подписчика
    public interface ISystemObserver
    {
        void Update(string message);
    }

    //Конкретные подписчики

    public class Admin : ISystemObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[Admin] Получено уведомление: {message}");
        }
    }

    public class DevOps : ISystemObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[DevOps] Получено уведомление: {message}");
        }
    }

    //Издатель
    public class ServerMonitor
    {
        private List<ISystemObserver> _observers = new List<ISystemObserver>();

        private int _serverLoad;

        public void Attach(ISystemObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ISystemObserver observer)
        {
            _observers.Remove(observer);
        }

        private void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void SetLoad(int load)
        {
            _serverLoad = load;
            Console.WriteLine($"Текущая нагрузка: {_serverLoad}%");

            if (_serverLoad > 80)
            {
                Notify("Сервер перегружен!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ServerMonitor monitor = new ServerMonitor();

            Admin admin = new Admin();
            DevOps devOps = new DevOps();

            monitor.Attach(admin);
            monitor.Attach(devOps);
            
            monitor.SetLoad(50);
            Console.WriteLine();

            monitor.SetLoad(90);
            Console.WriteLine();
            
            monitor.Detach(admin);

            monitor.SetLoad(95);
        }
    }
}