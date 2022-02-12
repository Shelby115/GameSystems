using GameSystems.Entity;

namespace GameSystems.Map
{
    public interface IMap
    {
        public int Width { get; }
        public int Depth { get; }
        public int Height { get; }
        public MapPositionInfo[,,] Positions { get; }
        public IEnumerable<ICanMove> Members { get; }
        public IDictionary<ICanMove, MapPositionInfo> MemberPositions { get; }

        public event MoveEventHandler? BeforeMove;
        public event MoveEventHandler? AfterMove;

        /// <summary>
        /// Teleports the mover to the specified map position.
        /// Does not fire any events.
        /// </summary>
        /// <param name="mover">Character being moved.</param>
        /// <param name="position">Position they are going.</param>
        void SetPosition(ICanMove mover, MapPositionInfo position);

        /// <summary>
        /// Moves the character to the specified map position and fired move events.
        /// </summary>
        /// <param name="mover">Character that is being moved.</param>
        /// <param name="position">Position they are going.</param>
        void Move(ICanMove mover, MapPositionInfo position);

        /// <summary>
        /// Converts map position coordinates to game position coordinates.
        /// </summary>
        /// <param name="mapPosition">Map coordinates to be converted.</param>
        /// <returns>A tuple of game coordinates.</returns>
        (float x, float y, float z) ConvertFromMapPosition(MapPositionInfo mapPosition);

        /// <summary>
        /// Converts game coordinates to map coordinates.
        /// </summary>
        /// <param name="x">Game position x coordinates.</param>
        /// <param name="y">Game position y coordinates.</param>
        /// <param name="z">Game position z coordinates.</param>
        /// <returns>A MapPosition coordinate object.</returns>
        MapPositionInfo ConvertToMapPosition(float x, float y, float z);
    }
}