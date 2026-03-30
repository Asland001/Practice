using DecoratorApp.GameCharacters;

namespace DecoratorApp.Decorators
{
    public class HealingDecorator : CharacterDecorator
    {
        public HealingDecorator(IGameCharacter character)
            : base(character) { }

        public override string GetAbilities()
        {
            return base.GetAbilities() + ", Лечение";
        }
    }
}