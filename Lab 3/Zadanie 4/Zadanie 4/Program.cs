using System;

namespace MovieSystem
{
    class Program
    {
        static void Main()
        {
            Movie[] movies =
            {
                new Movie("Inception", "Nolan", 148, "Sci-Fi"),
                new Movie("Interstellar", "Nolan", 169, "Sci-Fi"),
                new Movie("Titanic", "Cameron", 195, "Drama"),
                new Movie("Avatar", "Cameron", 162, "Fantasy")
            };

            Cinema cinema = new Cinema(movies);

            //Самый длинный фильм
            Console.WriteLine("Самый длинный фильм:");
            cinema.GetLongestMovie().Display();

            //Фильмы режиссёра
            Console.WriteLine("\nФильмы Nolan:");
            var list = cinema.GetMoviesByDirector("Nolan");

            foreach (var m in list)
            {
                m.Display();
            }

            Console.ReadKey();
        }
    }
}