using FactoryMethodAppZadanie.Animals;

namespace FactoryMethodAppZadanie.Factories
{
    public class CatFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Cat();
        }
    }
}