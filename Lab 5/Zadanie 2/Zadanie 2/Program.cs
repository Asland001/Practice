using System;

namespace CinemaAppZadanie
{
    //Класс фильма
    public class Movie
    {
        public string Title { get; set; }

        public Movie(string title)
        {
            Title = title;
        }
    }

    //Класс расписания
    public class Schedule
    {
        public string Time { get; set; }

        public Schedule(string time)
        {
            Time = time;
        }
    }

    //Класс дистрибьютора (ассоциация)
    public class Distributor
    {
        public string Name { get; set; }

        public Distributor(string name)
        {
            Name = name;
        }
    }

    //Класс кинотеатра
    public class Cinema
    {
        public string Name { get; set; }
        
        public Movie[] Movies { get; set; }
        
        private Schedule _schedule;
        
        public Distributor Distributor { get; set; }

        public Cinema(string name, Movie[] movies, Distributor distributor)
        {
            Name = name;
            Movies = movies;
            Distributor = distributor;
            
            _schedule = new Schedule("18:00");
        }

        //Бизнес-логика
        public void ShowMovies()
        {
            Console.WriteLine($"Кинотеатр: {Name}");
            Console.WriteLine($"Дистрибьютор: {Distributor.Name}");
            Console.WriteLine($"Время сеанса: {_schedule.Time}");

            Console.WriteLine("Фильмы:");

            foreach (Movie movie in Movies)
            {
                Console.WriteLine($"- {movie.Title}");
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Movie movie1 = new Movie("Интерстеллар");
            Movie movie2 = new Movie("Форсаж");

            Movie[] movies = { movie1, movie2 };
            
            Distributor distributor = new Distributor("Warner Bros");
            
            Cinema[] cinemas = new Cinema[2];

            cinemas[0] = new Cinema("Mooon", movies, distributor);
            cinemas[1] = new Cinema("Mega Cinema", movies, distributor);
            
            foreach (Cinema cinema in cinemas)
            {
                cinema.ShowMovies();
            }
        }
    }
}