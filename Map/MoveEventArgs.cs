using GameSystems.Map;

namespace GameSystems.Entity
{
    public delegate void MoveEventHandler(ICanMove mover, MoveEventArgs e);
    public class MoveEventArgs : EventArgs
    {
        public MapPositionInfo OldPosition { get; }
        public MapPositionInfo NewPosition { get; }

        public MoveEventArgs(MapPositionInfo oldPosition, MapPositionInfo newPosition)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
        }
    }
}