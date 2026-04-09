using System.IO.MemoryMappedFiles;
using System.Text;

namespace CinemaApp.Services
{
    public class NotificationService
    {
        private const string MapName = "CinemaNotifications";

        public void Send(string message)
        {
            using var mmf = MemoryMappedFile.CreateOrOpen(MapName, 1024);
            using var stream = mmf.CreateViewStream();
            var bytes = Encoding.UTF8.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

        public string Receive()
        {
            using var mmf = MemoryMappedFile.OpenExisting(MapName);
            using var stream = mmf.CreateViewStream();
            byte[] buffer = new byte[1024];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer).Trim('\0');
        }
    }
}