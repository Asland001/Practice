using System;

namespace ImageProcessingAppZadanie
{
    public delegate void ImageProcessor(string path);

    public class ImageService
    {
        //Метод, принимающий делегат (callback)
        public void ProcessImage(string path, ImageProcessor processor)
        {
            Console.WriteLine($"Обработка изображения: {path}");
            processor(path);
            Console.WriteLine("Обработка завершена\n");
        }

        //Метод 1: изменение размера
        public void ResizeImage(string path)
        {
            Console.WriteLine($"Изображение {path} изменено по размеру");
        }

        //Метод 2: перевод в ч/б
        public void ConvertToGrayscale(string path)
        {
            Console.WriteLine($"Изображение {path} преобразовано в чёрно-белое");
        }
    }

    class Program
    {
        static void Main()
        {
            ImageService service = new ImageService();

            string imagePath = "D:\\Флешка\\Practice\\Lab 6\\Zadanie 2\\Zadanie 2\\bin\\Debug\\net8.0\\photo.jpg";
            
            service.ProcessImage(imagePath, service.ResizeImage);
            
            service.ProcessImage(imagePath, service.ConvertToGrayscale);
        }
    }
}