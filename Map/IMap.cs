using GameSystems.Character;

namespace GameSystems.Map
{
    public interface IMap
    {
        /// <summary>
        /// Size of the map in the X-axis.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Size of the map in the Y-axis.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Size of the map in the Z-axis.
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Retrieves a collection of all the map tiles.
        /// </summary>
        IEnumerable<MapTile> GetMapTiles();

        /// <summary>
        /// Retrieves a tile at the specified position.
        /// </summary>
        /// <param name="position">Position of the desired tile.</param>
        MapTile GetMapTile(MapPosition position);

        /// <summary>
        /// Event that is triggered before a member of the map moves (should exclude teleports).
        /// </summary>
        event MoveEventHandler? BeforeMove;

        /// <summary>
        /// Event that is triggered after a member of the map had moved (should exclude teleports).
        /// </summary>
        event MoveEventHandler? AfterMove;

        /// <summary>
        /// Event that is triggered before a member is added to the map.
        /// </summary>
        event MoveEventHandler? BeforeMemberAdded;

        /// <summary>
        /// Event that is triggered after a member is added to the map.
        /// </summary>
        event MoveEventHandler? AfterMemberAdded;

        /// <summary>
        /// Event that is triggered before a member is removed from the map.
        /// </summary>
        event MoveEventHandler? BeforeMemberRemoved;

        /// <summary>
        /// Event that is triggered after a member is removed from the map.
        /// </summary>
        event MoveEventHandler? AfterMemberRemoved;

        /// <summary>
        /// Adds a member to the map at the specified position.
        /// </summary>
        /// <param name="member">Member to be added to the map.</param>
        /// <param name="mapPosition">Position on the map to add the member.</param>
        void AddMemberAtPosition(ICanMove member, MapPosition mapPosition);

        /// <summary>
        /// Removes a member from the map.
        /// </summary>
        /// <param name="member">Member to be removed from the map.</param>
        void RemoveMember(ICanMove member);

        /// <summary>
        /// Teleports the mover to the specified map position.
        /// </summary>
        /// <param name="mover">Character being moved.</param>
        /// <param name="position">Position they are going.</param>
        void Teleport(ICanMove mover, MapPosition position);
        
        /// <summary>
        /// Moves the character to the specified map position.
        /// </summary>
        /// <param name="mover">Character that is being moved.</param>
        /// <param name="position">Position they are going.</param>
        void Move(ICanMove mover, MapPosition position);
    }
}