using System;

namespace SportsAppZadanie
{
    public class TeamMember
    {
        public string Name { get; set; }

        public TeamMember(string name)
        {
            Name = name;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Игрок: {Name}");
        }
    }

    //Интерфейс для баскетболистов
    public interface IBasketballPlayer
    {
        void Shoot();
    }

    //Интерфейс для футболистов
    public interface IFootballPlayer
    {
        void Kick();
    }

    //Класс баскетболиста
    public class Basketballer : TeamMember, IBasketballPlayer
    {
        public Basketballer(string name) : base(name) { }

        public void Shoot()
        {
            Console.WriteLine($"{Name} бросает мяч в корзину");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Баскетболист: {Name}");
        }
    }

    //Класс футболиста
    public class Footballer : TeamMember, IFootballPlayer
    {
        public Footballer(string name) : base(name) { }

        public void Kick()
        {
            Console.WriteLine($"{Name} бьёт по мячу");
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Футболист: {Name}");
        }
    }

    class Program
    {
        static void Main()
        {
            TeamMember[] team =
            {
                new Basketballer("Иван"),
                new Footballer("Алексей"),
                new Basketballer("Олег"),
                new Footballer("Руслан")
            };

            Console.WriteLine("Все игроки:");
            foreach (TeamMember member in team)
            {
                member.ShowInfo();
            }

            Console.WriteLine("\nБаскетболисты:");

            //Бизнес-логика: фильтрация по интерфейсу
            foreach (TeamMember member in team)
            {
                if (member is IBasketballPlayer basketballPlayer)
                {
                    basketballPlayer.Shoot();
                }
            }
        }
    }
}