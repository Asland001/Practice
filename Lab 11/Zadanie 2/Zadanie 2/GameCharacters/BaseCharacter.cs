namespace DecoratorApp.GameCharacters
{
    public class BaseCharacter : IGameCharacter
    {
        public string GetAbilities()
        {
            return "Стандартные способности";
        }
    }
}