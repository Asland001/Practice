using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CinemaApp.Services
{
    public class StorageService
    {
        public async Task SaveAsync<T>(string path, T data)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path) ?? "Data");

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        public T Load<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}