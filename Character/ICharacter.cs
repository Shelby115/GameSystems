namespace GameSystems.Entity
{
    public interface ICharacter : ICanMove, ITakeTurn
    {
        public Guid Id { get; }
        public string Name { get; }
    }
}