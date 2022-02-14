namespace GameSystems.Character
{
    public interface ICharacter
    {
        public Guid Id { get; }
        public string Name { get; }
        public Attributes Attributes { get; }
    }
}