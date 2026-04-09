using CinemaApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CinemaApp.Services
{
    public class CinemaService
    {
        private readonly string dataFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        private string cinemaPath => Path.Combine(dataFolder, "cinema.json");

        public CinemaDataModel LoadCinema()
        {
            try
            {
                Directory.CreateDirectory(dataFolder);

                if (!File.Exists(cinemaPath))
                {
                    var defaults = CreateDefaultCinemaData();
                    SaveCinemaAsync(defaults).Wait();
                    return defaults;
                }

                var json = File.ReadAllText(cinemaPath);

                if (string.IsNullOrWhiteSpace(json))
                {
                    var defaults = CreateDefaultCinemaData();
                    SaveCinemaAsync(defaults).Wait();
                    return defaults;
                }

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                CinemaDataModel data;

                if (root.ValueKind == JsonValueKind.Object)
                {
                    data = JsonSerializer.Deserialize<CinemaDataModel>(json) ?? CreateDefaultCinemaData();
                }
                else if (root.ValueKind == JsonValueKind.Array)
                {
                    var sessions = JsonSerializer.Deserialize<List<MovieSession>>(json) ?? new List<MovieSession>();
                    data = new CinemaDataModel
                    {
                        Sessions = sessions,
                        Tickets = new List<TicketModel>()
                    };
                }
                else
                {
                    data = CreateDefaultCinemaData();
                }

                if (!HasValidSessions(data.Sessions))
                {
                    data = CreateDefaultCinemaData();
                    SaveCinemaAsync(data).Wait();
                }

                return data;
            }
            catch
            {
                var defaults = CreateDefaultCinemaData();
                SaveCinemaAsync(defaults).Wait();
                return defaults;
            }
        }

        public async Task SaveCinemaAsync(CinemaDataModel data)
        {
            Directory.CreateDirectory(dataFolder);

            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await File.WriteAllTextAsync(cinemaPath, json);
        }

        public async Task<bool> BookSeatAsync(SeatModel seat)
        {
            await Task.Delay(2000);

            if (seat.IsBooked)
                return false;

            seat.IsBooked = true;
            return true;
        }

        private bool HasValidSessions(List<MovieSession> sessions)
        {
            if (sessions == null || sessions.Count == 0)
                return false;

            return sessions.All(s =>
                !string.IsNullOrWhiteSpace(s.MovieName) &&
                !string.IsNullOrWhiteSpace(s.Time) &&
                s.AvailableSeats > 0);
        }

        private CinemaDataModel CreateDefaultCinemaData()
        {
            return new CinemaDataModel
            {
                Sessions = new List<MovieSession>
                {
                    new MovieSession { MovieName = "Интерстеллар", Time = "18:00", AvailableSeats = 50 },
                    new MovieSession { MovieName = "Матрица", Time = "20:00", AvailableSeats = 40 },
                    new MovieSession { MovieName = "Джентльмены", Time = "22:00", AvailableSeats = 30 },
                    new MovieSession { MovieName = "1+1", Time = "21:00", AvailableSeats = 30 }
                },
                Tickets = new List<TicketModel>()
            };
        }
    }
}