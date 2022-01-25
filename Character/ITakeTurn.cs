namespace GameSystems.Entity
{
    public interface ITakeTurn
    {
        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler TurnEnded;
    }
}