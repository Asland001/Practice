using CinemaApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CinemaApp.Services
{
    public class CinemaService
    {
        private readonly string cinemaPath = Path.Combine("Data", "cinema.json");

        public async Task SaveCinemaAsync(object data)
        {
            Directory.CreateDirectory("Data");

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(cinemaPath, json);
        }

        public T LoadCinema<T>()
        {
            if (!File.Exists(cinemaPath))
                return default;

            var json = File.ReadAllText(cinemaPath);
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task<bool> BookSeatAsync(SeatModel seat)
        {
            await Task.Delay(2000);

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            return true;
        }

        public ObservableCollection<MovieSession> FilterByTime(IEnumerable<MovieSession> sessions, string timePart)
        {
            var filtered = sessions.Where(s => s.Time != null && s.Time.Contains(timePart)).ToList();
            return new ObservableCollection<MovieSession>(filtered);
        }
    }
}