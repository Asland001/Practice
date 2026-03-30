using FactoryMethodAppZadanie.Animals;

namespace FactoryMethodAppZadanie.Factories
{
    public class DogFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Dog();
        }
    }
}