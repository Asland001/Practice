using DecoratorApp.GameCharacters;

namespace DecoratorApp.Decorators
{
    public class StealthDecorator : CharacterDecorator
    {
        public StealthDecorator(IGameCharacter character)
            : base(character) { }

        public override string GetAbilities()
        {
            return base.GetAbilities() + ", Скрытность";
        }
    }
}