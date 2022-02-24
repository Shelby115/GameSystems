namespace GameSystems.Map
{
    public class MapGenerator : IMapGenerator
    {
        private const int MaxWaterHeight = 1;
        private const int WaterTileChance = 30;

        private readonly Random Random = new();

        public IDictionary<MapPosition, MapTile> GenerateMap(int width, int height, int depth)
        {
            var map = new Dictionary<MapPosition, MapTile>();

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < depth; z++)
                {
                    var maxHeight = Math.Min(Random.Next(height) + 1, height);
                    for (int y = 0; y < maxHeight; y++)
                    {
                        var position = new MapPosition(x, y, z);
                        var type = y < MaxWaterHeight && (Random.Next(100) + 1 >= WaterTileChance) ? "Water" : "Grass";
                        map.Add(position, new MapTile(position, type));
                    }
                }
            }

            return map;
        }
    }
}