using System;

namespace MovieSystem
{
    class Cinema
    {
        public Movie[] Movies { get; set; }

        public Cinema(Movie[] movies)
        {
            Movies = movies;
        }

        //Самый длинный фильм
        public Movie GetLongestMovie()
        {
            Movie max = Movies[0];

            foreach (var movie in Movies)
            {
                if (movie.Duration > max.Duration)
                    max = movie;
            }

            return max;
        }

        //Фильмы по режиссёру
        public Movie[] GetMoviesByDirector(string director)
        {
            Movie[] result = new Movie[Movies.Length];
            int count = 0;

            foreach (var movie in Movies)
            {
                if (movie.Director == director)
                {
                    result[count++] = movie;
                }
            }

            Array.Resize(ref result, count);
            return result;
        }
    }
}