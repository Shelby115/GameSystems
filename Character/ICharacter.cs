namespace GameSystems.Character
{
    public interface ICharacter
    {
        public Guid Id { get; }
        public string Name { get; }
        public IDictionary<string, int> Attributes { get; }
    }
}