using System;

namespace ExtensionMethodZadanie
{
    static class StringExtensions
    {
        //Расширяющий метод
        public static string GetFirstLetters(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string result = "";

            foreach (var word in words)
            {
                result += word[0];
            }

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            string input = "Конец девятнадцатого века. Крупный предприниматель Стивен Стил решает организовать событие, которое всколыхнёт мир. По всей Америке разносятся слухи о том, что на западе страны начинаются величайшие в истории скачки. Отвесные скалы, песчаные дюны, раскалённое солнце и путешествие по бескрайним пустошам длиною в шесть тысяч километров — это гонка «Стальной шар». Лучшие скакуны со всего света готовы попытать удачу ради всемирной славы и главного приза в пятьдесят миллионов долларов.\n";

            string result = input.GetFirstLetters();

            Console.WriteLine(result); // HWfC

            Console.ReadKey();
        }
    }
}