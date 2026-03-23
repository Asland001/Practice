using System;

namespace LoginAppZadanie
{
    public class UserLoginManager
    {
        //Событие на основе EventHandler
        public event EventHandler UserLoggedIn;

        public void Login(string username)
        {
            Console.WriteLine($"Пользователь {username} вошёл в систему");
            
            OnUserLoggedIn();
        }

        protected virtual void OnUserLoggedIn()
        {
            UserLoggedIn?.Invoke(this, EventArgs.Empty);
        }
    }

    //Подписчик 1
    public class SecuritySystem
    {
        public void CheckAccess(object sender, EventArgs e)
        {
            Console.WriteLine("SecuritySystem: доступ проверен");
        }
    }

    //Подписчик 2
    public class NotificationService
    {
        public void SendNotification(object sender, EventArgs e)
        {
            Console.WriteLine("NotificationService: уведомление отправлено");
        }
    }

    //Промежуточный класс (Observer)
    public class LoginObserver
    {
        private readonly UserLoginManager _manager;
        private readonly SecuritySystem _security;
        private readonly NotificationService _notification;

        public LoginObserver(UserLoginManager manager,
                             SecuritySystem security,
                             NotificationService notification)
        {
            _manager = manager;
            _security = security;
            _notification = notification;
            
            _manager.UserLoggedIn += _security.CheckAccess;
            _manager.UserLoggedIn += _notification.SendNotification;
        }
    }

    class Program
    {
        static void Main()
        {
            UserLoginManager manager = new UserLoginManager();

            SecuritySystem security = new SecuritySystem();
            NotificationService notification = new NotificationService();
            
            LoginObserver observer = new LoginObserver(manager, security, notification);
            
            manager.Login("Island");
        }
    }
}