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

        public UserModel Login(string login, string password)
        {
            if (!File.Exists(usersPath))
                return null;

            var json = File.ReadAllText(usersPath);
            var users = JsonSerializer.Deserialize<List<UserModel>>(json);

            return users?.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public void Register(UserModel user)
        {
            var users = GetUsers();
            users.Add(user);
            SaveUsers(users);
        }

        public List<UserModel> GetUsers()
        {
            if (!File.Exists(usersPath))
                return new List<UserModel>();

            var json = File.ReadAllText(usersPath);
            return JsonSerializer.Deserialize<List<UserModel>>(json) ?? new List<UserModel>();
        }

        public void SaveUsers(List<UserModel> users)
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