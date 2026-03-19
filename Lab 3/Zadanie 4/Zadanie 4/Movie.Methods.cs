using System;

namespace MovieSystem
{
    public partial class Movie
    {
        public void Display()
        {
            Console.WriteLine($"{Title} | {Director} | {Duration} мин | {Genre}");
        }
    }
}