using FactoryMethodAppZadanie.Animals;

namespace FactoryMethodAppZadanie.Factories
{
    public class BirdFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Bird();
        }
    }
}