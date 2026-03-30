using FactoryMethodAppZadanie.Animals;

namespace FactoryMethodAppZadanie.Factories
{
    public abstract class AnimalFactory
    {
        public abstract IAnimal CreateAnimal();
    }
}