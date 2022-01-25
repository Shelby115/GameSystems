using GameSystems.Map;

namespace GameSystems.Entity
{
    public delegate void MoveEventHandler(ICanMove mover, MoveEventArgs e);
    public class MoveEventArgs : EventArgs
    {
        public MapPosition OldPosition { get; }
        public MapPosition NewPosition { get; }

        public MoveEventArgs(MapPosition oldPosition, MapPosition newPosition)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
    }
}