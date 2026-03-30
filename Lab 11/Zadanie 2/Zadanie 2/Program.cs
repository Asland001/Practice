using System;
using DecoratorApp.GameCharacters;
using DecoratorApp.Decorators;

namespace DecoratorAppZadanie
{
    class Program
    {
        static void Main()
        {
            //Стандартный персонаж
            IGameCharacter character = new BaseCharacter();

            Console.WriteLine("Стандартный:");
            Console.WriteLine(character.GetAbilities());

            Console.WriteLine();

            //Добавление способностей
            character = new StealthDecorator(character);
            character = new PowerAttackDecorator(character);
            character = new HealingDecorator(character);

            Console.WriteLine("После улучшений:");
            Console.WriteLine(character.GetAbilities());
        }
    }
}