using GameSystems.Map;

namespace GameSystems.Entity
{
    public interface ICanMove
    {
        public int MaxMoveDistance { get; }
        public MapPosition Position { get; }
        public bool Move(MapPosition position);
    }
}