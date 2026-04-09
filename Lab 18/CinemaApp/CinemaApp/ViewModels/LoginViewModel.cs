using CinemaApp.Models;
using CinemaApp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CinemaApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AuthService authService = new AuthService();

        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public bool TryLogin(string password, out string message)
        {
            message = string.Empty;

            var user = authService.Login(Login, password);

            if (user == null)
            {
                message = "Неверный логин или пароль.";
                return false;
            }

            message = $"Добро пожаловать, {user.Login}! Роль: {user.Role}";
            return true;
        }

        public bool TryRegister(string password, out string message)
        {
            var user = new UserModel
            {
                Login = Login,
                Password = password,
                Role = "user"
            };

            return authService.Register(user, out message);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}