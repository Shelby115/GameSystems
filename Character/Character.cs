namespace GameSystems.Entity
{
    public class Character : ICharacter, ICanMove, ITakeTurns
    {
        #region ICharacter

        public Guid Id { get; }
        public string Name { get; }

        #endregion ICharacter

        #region ICanMove

        public int MaxMoveDistance { get; protected set; }


        #endregion ICanMove

        #region ITakeTurn

        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler? TurnEnded;


        #endregion ITakeTurn

        public Character(Guid id, string name, string faction)
        {
            Id = id;
            Name = name;
            Faction = faction;
        }
    }
}