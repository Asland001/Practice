using System;
using System.IO;

namespace FileAppZadanie
{
    public class FileManager
    {
        public void CreateAndWrite(string path, string content)
        {
            File.WriteAllText(path, content);
            Console.WriteLine("Файл создан и записан");
        }

        public void ReadFile(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(File.ReadAllText(path));
            }
        }

        public void DeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine("Файл удалён");
                }
                else
                {
                    Console.WriteLine("Файл не существует");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка удаления: {ex.Message}");
            }
        }

        public void CopyFile(string source, string destination)
        {
            File.Copy(source, destination, true);
            Console.WriteLine("Файл скопирован");
        }

        public void MoveFile(string source, string destination)
        {
            File.Move(source, destination, true);
            Console.WriteLine("Файл перемещён");
        }

        public void RenameFile(string source, string newName)
        {
            string directory = Path.GetDirectoryName(source);
            string newPath = Path.Combine(directory, newName);
            File.Move(source, newPath, true);
            Console.WriteLine("Файл переименован");
        }

        public void DeleteByExtension(string folder, string extension)
        {
            string[] files = Directory.GetFiles(folder, $"*.{extension}");

            foreach (string file in files)
            {
                File.Delete(file);
            }

            Console.WriteLine("Файлы удалены по расширению");
        }

        public void ListFiles(string folder)
        {
            string[] files = Directory.GetFiles(folder);

            Console.WriteLine("Файлы в папке:");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        public void WriteProtectedFile(string path)
        {
            File.SetAttributes(path, FileAttributes.ReadOnly);

            try
            {
                File.WriteAllText(path, "Попытка записи");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи: {ex.Message}");
            }
        }
    }
    
    public class FileInfoProvider
    {
        public void ShowInfo(string path)
        {
            if (File.Exists(path))
            {
                FileInfo info = new FileInfo(path);

                Console.WriteLine($"Размер: {info.Length} байт");
                Console.WriteLine($"Создан: {info.CreationTime}");
                Console.WriteLine($"Изменён: {info.LastWriteTime}");
            }
        }

        public void CompareFiles(string file1, string file2)
        {
            FileInfo f1 = new FileInfo(file1);
            FileInfo f2 = new FileInfo(file2);

            if (f1.Length == f2.Length)
                Console.WriteLine("Файлы одинаковы по размеру");
            else
                Console.WriteLine("Файлы разные по размеру");
        }

        public void CheckAccess(string path)
        {
            FileInfo info = new FileInfo(path);

            Console.WriteLine($"Только чтение: {info.IsReadOnly}");
        }
    }

    class Program
    {
        static void Main()
        {
            FileManager manager = new FileManager();
            FileInfoProvider info = new FileInfoProvider();

            string file = "ivanov.ii";
            string copy = "copy.ii";
            string moved = "newfolder\\moved.ii";

            Directory.CreateDirectory("newfolder");

            //Z1
            manager.CreateAndWrite(file, "Реинкарнация аристократа: Благословенный с рождения величайшей силой");
            manager.ReadFile(file);

            //Z2 + 7
            manager.DeleteFile("nofile.ii");

            //Z3
            info.ShowInfo(file);

            //Z4
            manager.CopyFile(file, copy);

            //Z8
            info.CompareFiles(file, copy);

            //Z5
            manager.MoveFile(copy, moved);

            //Z6
            manager.RenameFile(file, "ivanov.io");

            //Z9
            manager.DeleteByExtension(".", "ii");

            //Z10
            manager.ListFiles(".");

            //z11
            manager.CreateAndWrite("test.txt", "data");
            manager.WriteProtectedFile("test.txt");

            //Z12
            info.CheckAccess("test.txt");
        }
    }
}