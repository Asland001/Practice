using DecoratorApp.GameCharacters;

namespace DecoratorApp.Decorators
{
    public class PowerAttackDecorator : CharacterDecorator
    {
        public PowerAttackDecorator(IGameCharacter character)
            : base(character) { }

        public override string GetAbilities()
        {
            return base.GetAbilities() + ", Мощная атака";
        }
    }
}