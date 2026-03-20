using System;

namespace FoodSystemZadanie
{
    abstract class Food
    {
        public abstract void Cook();
        
        public virtual void Serve()
        {
            Console.WriteLine("Food is served");
        }
    }

    //Класс Pizza
    class Pizza : Food
    {
        public override void Cook()
        {
            Console.WriteLine("Pizza is cooking");
        }

        public override void Serve()
        {
            Console.WriteLine("Pizza is served");
        }
    }

    //Класс Pasta
    class Pasta : Food
    {
        public override void Cook()
        {
            Console.WriteLine("Pasta is cooking");
        }

        public override void Serve()
        {
            Console.WriteLine("Pasta is served");
        }
    }

    class Program
    {
        static void Main()
        {
            Food pizza = new Pizza();
            Food pasta = new Pasta();

            pizza.Cook();
            pizza.Serve();

            Console.WriteLine();

            pasta.Cook();
            pasta.Serve();

            Console.ReadKey();
        }
    }
}