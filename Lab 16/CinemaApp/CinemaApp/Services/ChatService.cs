using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace CinemaApp.Services
{
    public class ChatService
    {
        private const string PipeName = "cinema_chat_pipe";

        public async Task StartServerAsync()
        {
            using var server = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            await server.WaitForConnectionAsync();

            using var reader = new StreamReader(server);
            using var writer = new StreamWriter(server) { AutoFlush = true };

            string incoming = await reader.ReadLineAsync();
            await writer.WriteLineAsync($"Сервер получил: {incoming}");
        }

        public async Task<string> SendMessageAsync(string message)
        {
            using var client = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
            await client.ConnectAsync(3000);

            using var writer = new StreamWriter(client) { AutoFlush = true };
            using var reader = new StreamReader(client);

            await writer.WriteLineAsync(message);
            return await reader.ReadLineAsync();
        }
    }
}