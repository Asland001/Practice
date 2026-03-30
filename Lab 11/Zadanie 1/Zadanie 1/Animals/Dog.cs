using System;

namespace FactoryMethodAppZadanie.Animals
{
    public class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Собака: Гав-гав");
        }
    }
}