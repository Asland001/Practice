using System;
using System.IO;

namespace FileWatcherAppZadanie
{
    public class FileWatcher
    {
        private readonly FileSystemWatcher _watcher;
        private readonly string _path;

        public FileWatcher(string path)
        {
            _path = path;

            _watcher = new FileSystemWatcher(path);
            
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.Changed += OnChanged;
            _watcher.Renamed += OnRenamed;

            _watcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Событие: {e.ChangeType}, Файл: {e.Name}");
            ShowFileCount();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Переименован: {e.OldName} -> {e.Name}");
            ShowFileCount();
        }
        
        private void ShowFileCount()
        {
            int count = Directory.GetFiles(_path).Length;
            Console.WriteLine($"Количество файлов в папке: {count}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            string path = ".";

            Console.WriteLine("Отслеживание папки запущено...\n");

            FileWatcher watcher = new FileWatcher(path);
            
            Console.ReadLine();
        }
    }
}