using CinemaApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CinemaApp.Services
{
    public class AuthService
    {
        private readonly string usersPath = Path.Combine("Data", "users.json");

        public AuthService()
        {
            EnsureUsersFile();
        }

        private void EnsureUsersFile()
        {
            Directory.CreateDirectory("Data");

            if (File.Exists(usersPath))
                return;

            var defaultUsers = new List<UserModel>
            {
                new UserModel { Login = "admin", Password = "1234", Role = "admin" },
                new UserModel { Login = "user", Password = "1111", Role = "user" }
            };

            SaveUsers(defaultUsers);
        }

        public List<UserModel> GetUsers()
        {
            EnsureUsersFile();

            var json = File.ReadAllText(usersPath);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        public UserModel Login(string login, string password)
        {
            login = login?.Trim();
            password = password?.Trim();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return null;

            var users = GetUsers();
            return users.FirstOrDefault(u =>
                u.Login != null &&
                u.Password != null &&
                u.Login.Trim() == login &&
                u.Password.Trim() == password);
        }

        public bool Register(UserModel user, out string message)
        {
            message = string.Empty;

            if (user == null)
            {
                message = "Некорректные данные.";
                return false;
            }

            user.Login = user.Login?.Trim();
            user.Password = user.Password?.Trim();

            if (string.IsNullOrWhiteSpace(user.Login) || string.IsNullOrWhiteSpace(user.Password))
            {
                message = "Введите логин и пароль.";
                return false;
            }

            var users = GetUsers();

            if (users.Any(u => u.Login != null && u.Login.Trim().Equals(user.Login, System.StringComparison.OrdinalIgnoreCase)))
            {
                message = "Пользователь с таким логином уже существует.";
                return false;
            }

            users.Add(user);
            SaveUsers(users);

            message = "Пользователь успешно зарегистрирован.";
            return true;
        }

        private void SaveUsers(List<UserModel> users)
        {
            Directory.CreateDirectory("Data");

            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(usersPath, json);
        }
    }
}