using System;
using FactoryMethodAppZadanie.Animals;
using FactoryMethodAppZadanie.Factories;

namespace FactoryMethodAppZadanie
{
    class Program
    {
        static void Main()
        {
            AnimalFactory factory;

            factory = new DogFactory();
            IAnimal dog = factory.CreateAnimal();
            dog.MakeSound();

            factory = new CatFactory();
            IAnimal cat = factory.CreateAnimal();
            cat.MakeSound();

            factory = new BirdFactory();
            IAnimal bird = factory.CreateAnimal();
            bird.MakeSound();
        }
    }
}