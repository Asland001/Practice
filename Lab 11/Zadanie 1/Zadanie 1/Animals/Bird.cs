using System;

namespace FactoryMethodAppZadanie.Animals
{
    public class Bird : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Птица: Чирик");
        }
    }
}