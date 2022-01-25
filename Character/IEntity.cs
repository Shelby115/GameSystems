namespace GameSystems.Entity
{
    public interface IEntity : ICanMove
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler TurnEnded;
    }
}