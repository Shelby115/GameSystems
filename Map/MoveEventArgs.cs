using GameSystems.Character;

namespace GameSystems.Map
{
    public delegate void MoveEventHandler(ICanMove mover, MoveEventArgs e);
    public class MoveEventArgs : EventArgs
    {
        /// <summary>
        /// BeforeMove: Where the mover is currently.
        /// AfterMove: Where the mover is going.
        /// </summary>
        public MapPosition OldPosition { get; }

        /// <summary>
        /// BeforeMove: Where the mover was before moving.
        /// AfterMove: Where the mover is currently.
        /// </summary>
        public MapPosition NewPosition { get; }

        /// <summary>
        /// Is the new position the mover's end destination?
        /// This flag will be false for every position along the mover's path except the position they stop at.
        /// </summary>
        public bool IsDestination { get; }

        /// <summary>
        /// Creates an arguments object for a move event (before or after).
        /// </summary>
        /// <param name="oldPosition">Before moving this is where the mover is currently. After moving this is where the mover came from.</param>
        /// <param name="newPosition">Before moving this is where the mover is going. After moving this is where the mover is currently.</param>
        /// <param name="isDestination">If this is a position on the way to another, this should be false. If this is the mover's desired location (ending position) this should be true.</param>
        public MoveEventArgs(MapPosition oldPosition, MapPosition newPosition, bool isDestination)
        {
            OldPosition = oldPosition;
            NewPosition = newPosition;
            IsDestination = isDestination;
        }
    }
}