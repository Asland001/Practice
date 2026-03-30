using DecoratorApp.GameCharacters;

namespace DecoratorApp.Decorators
{
    public abstract class CharacterDecorator : IGameCharacter
    {
        protected IGameCharacter _character;

        protected CharacterDecorator(IGameCharacter character)
        {
            _character = character;
        }

        public virtual string GetAbilities()
        {
            return _character.GetAbilities();
        }
    }
}