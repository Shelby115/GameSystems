using GameSystems.Character;

namespace GameSystems.Map
{
    public class Map : IMap
    {
        public int Width { get; }
        public int Depth { get; }
        public int Height { get; }

        public IEnumerable<MapTile> GetMapTiles() => Tiles.Values;
        public MapTile GetMapTile(MapPosition position) => Tiles[position];

        public event MoveEventHandler? BeforeMove;
        public event MoveEventHandler? AfterMove;

        public event MoveEventHandler? BeforeMemberAdded;
        public event MoveEventHandler? AfterMemberAdded;

        public event MoveEventHandler? BeforeMemberRemoved;
        public event MoveEventHandler? AfterMemberRemoved;

        private IDictionary<ICanMove, MapPosition> MemberPositions { get; }
        private IDictionary<MapPosition, MapTile> Tiles { get; }

        /// <summary>
        /// A map with a specified width, height, and depth.
        /// </summary>
        /// <param name="width">The number of map tiles wide (X-axis) the map will be.</param>
        /// <param name="height">The number of map tiles tall (Y-axis) the map will be.</param>
        /// <param name="depth">The number of map tiles deep (Z-axis) the map will be.</param>
        /// <param name="mapGenerator">A map generator to populate the map with tiles. You could use a random map generator or create a custom implementation.</param>
        public Map(int width, int height, int depth, IMapGenerator mapGenerator)
        {
            Width = width;
            Depth = depth;
            Height = height;

            Tiles = mapGenerator.GenerateMap(width, height, depth);

            MemberPositions = new Dictionary<ICanMove, MapPosition>();
        }

        /// <summary>
        /// Adds a member to the map at the specified position.
        /// Triggers the <see cref="BeforeMemberAdded"/> and <see cref="AfterMemberAdded"/> events.
        /// </summary>
        /// <param name="member">Member to be added to the map.</param>
        /// <param name="mapPosition">Position on the map to add the member.</param>
        public void AddMemberAtPosition(ICanMove member, MapPosition mapPosition)
        {
            var args = new MoveEventArgs(mapPosition, mapPosition, true);
            BeforeMemberAdded?.Invoke(member, args);
            MemberPositions.Add(member, mapPosition);
            AfterMemberAdded?.Invoke(member, args);
        }

        /// <summary>
        /// Removes a member from the map.
        /// Triggers the <see cref="BeforeMemberRemoved"/> and <see cref="AfterMemberRemoved"/> events.
        /// </summary>
        /// <param name="member">Member to be removed from the map.</param>
        public void RemoveMember(ICanMove member)
        {
            var args = new MoveEventArgs(MemberPositions[member], MemberPositions[member], true);
            BeforeMemberRemoved?.Invoke(member, args);
            MemberPositions.Remove(member);
            AfterMemberRemoved?.Invoke(member, args);
        }

        /// <summary>
        /// Teleports the mover to the specified map position.
        /// Does not fire any move events.
        /// </summary>
        /// <param name="mover">Character being moved.</param>
        /// <param name="position">Position they are going.</param>
        public void Teleport(ICanMove mover, MapPosition position)
        {
            MemberPositions[mover] = position;
        }

        /// <summary>
        /// Moves the character to the specified map position.
        /// Triggers the <see cref="BeforeMove"/> and <see cref="AfterMove"/> events.
        /// </summary>
        /// <param name="mover">Character that is being moved.</param>
        /// <param name="position">Position they are going.</param>
        public void Move(ICanMove mover, MapPosition position)
        {
            if (mover.MaxMoveDistance < MemberPositions[mover].DistanceFrom(position)) { return; }
            var moveArgs = new MoveEventArgs(MemberPositions[mover], position, isDestination: true);
            BeforeMove?.Invoke(mover, moveArgs);
            MemberPositions[mover] = position;
            AfterMove?.Invoke(mover, moveArgs);
        }
    }
}