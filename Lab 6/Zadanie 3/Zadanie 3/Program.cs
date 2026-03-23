using System;

namespace BatteryAppZadanie 
{
    public delegate void BatteryLowHandler(int level);

    //Класс-издатель
    public class BatteryMonitor
    {
        public int BatteryLevel { get; set; }

        //Событие на основе делегата
        public event BatteryLowHandler BatteryLow;

        public BatteryMonitor(int level)
        {
            BatteryLevel = level;
        }

        //Метод проверки заряда
        public void CheckBattery()
        {
            Console.WriteLine($"Текущий заряд: {BatteryLevel}%");

            if (BatteryLevel < 21)
            {
                OnBatteryLow();
            }
        }

        //Метод вызова события
        protected void OnBatteryLow()
        {
            Console.WriteLine("Низкий заряд батареи!");

            BatteryLow?.Invoke(BatteryLevel);
        }
    }

    //Подписчик 1
    public class PowerSaver
    {
        public void Activate(int level)
        {
            Console.WriteLine("Режим энергосбережения включён");
        }
    }

    //Подписчик 2
    public class UserNotifier
    {
        public void Notify(int level)
        {
            Console.WriteLine($"Пользователь предупреждён: заряд {level}%");
        }
    }

    class Program
    {
        static void Main()
        {
            BatteryMonitor monitor = new BatteryMonitor(20);

            PowerSaver saver = new PowerSaver();
            UserNotifier notifier = new UserNotifier();
            
            monitor.BatteryLow += saver.Activate;
            monitor.BatteryLow += notifier.Notify;
            
            monitor.CheckBattery();
        }
    }
}