namespace GameSystems.Map
{
    public class Map : IMap
    {
        public int Width { get; }
        public int Depth { get; }
        public int Height { get; }
        public MapPosition[,,] Position { get; }

        private readonly float MapPositionWidth;
        private readonly float MapPositionDepth;
        private readonly float MapPositionHeight;

        /// <summary>
        /// A game map of specified Width (X), Depth (Y), and Height (Z).
        /// The map position values are used to convert between game and map coordinates.
        /// </summary>
        /// <param name="width">The number of map positions (i.e. tiles) wide the map will be.</param>
        /// <param name="depth">The number of map positions (i.e. tiles) deep the map will be.</param>
        /// <param name="height">The number of map positions (i.e. tiles) tall the map will be.</param>
        /// <param name="mapPositionWidth">The width in game of a single map position (i.e. tile). Used for converting between map coordinates and game coordinates.</param>
        /// <param name="mapPositionDepth">The depth in game of a single map position (i.e. tile). Used for converting between map coordinates and game coordinates.</param>
        /// <param name="mapPositionHeight">The height in game of a single map position (i.e. tile). Used for converting between map coordinates and game coordinates.</param>
        public Map(int width, int depth, int height, float mapPositionWidth, float mapPositionDepth, float mapPositionHeight)
        {
            Width = width;
            Depth = depth;
            Height = height;

            MapPositionWidth = mapPositionWidth;
            MapPositionDepth = mapPositionDepth;
            MapPositionHeight = mapPositionHeight;

            Position = new MapPosition[width, depth, height];
            for (int x = 0; x < Width; x++)
            {
               for (int y = 0; y < Depth; y++)
                {
                    for (int z = 0; z < Height; z++)
                    {
                        Position[x, y, z] = new MapPosition(x, y, z);
                    }
                }
            }
        }

        /// <summary>
        /// Converts map position coordinates to game position coordinates.
        /// </summary>
        /// <param name="mapPosition">Map coordinates to be converted.</param>
        /// <returns>A tuple of game coordinates.</returns>
        public (float x, float y, float z) ConvertFromMapPosition(MapPosition mapPosition)
        {
            return (
                x: mapPosition.X * MapPositionWidth,
                y: mapPosition.Y * MapPositionDepth,
                z: mapPosition.Z * MapPositionHeight
            );
        }

        /// <summary>
        /// Converts game coordinates to map coordinates.
        /// </summary>
        /// <param name="x">Game position x coordinates.</param>
        /// <param name="y">Game position y coordinates.</param>
        /// <param name="z">Game position z coordinates.</param>
        /// <returns>A MapPosition coordinate object.</returns>
        public MapPosition ConvertToMapPosition(float x, float y, float z)
        {
            return new MapPosition(
                x: Convert.ToInt32(x / MapPositionWidth),
                y: Convert.ToInt32(y / MapPositionDepth),
                z: Convert.ToInt32(z / MapPositionHeight)
            );
        }
    }
}