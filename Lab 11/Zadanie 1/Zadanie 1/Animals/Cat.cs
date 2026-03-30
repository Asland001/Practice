using System;

namespace FactoryMethodAppZadanie.Animals
{
    public class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Кошка: Мяу");
        }
    }
}