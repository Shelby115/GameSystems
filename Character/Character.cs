using GameSystems.Map;

namespace GameSystems.Entity
{
    public class Character : ICharacter
    {
        public Guid Id { get; }
        public string Name { get; }

        public Character(Guid id, string name, string faction, MapPosition mapPosition = default)
        {
            Id = id;
            Name = name;
            Faction = faction;
            Position = mapPosition;
            IsDead = true;
        }

        #region ICanMove

        public event MoveEventHandler OnBeforeMove;
        public event MoveEventHandler OnAfterMove;
        public MapPosition Position { get; protected set; }
        public int MaxMoveDistance { get; protected set; }

        public bool Move(MapPosition mapPosition)
        {
            if (MaxMoveDistance < Position.DistanceFrom(mapPosition)) { return false; }
            var moveArgs = new MoveEventArgs(this.Position, mapPosition);
            OnBeforeMove?.Invoke(this, moveArgs);
            Position = mapPosition;
            OnAfterMove?.Invoke(this, moveArgs);
            return true;
        }

        #endregion ICanMove

        #region ITakeTurn

        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler TurnEnded;


        #endregion ITakeTurn
    }
}