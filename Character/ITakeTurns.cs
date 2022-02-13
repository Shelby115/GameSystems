namespace GameSystems.Character
{
    public interface ITakeTurns
    {
        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler? TurnEnded;
    }
}