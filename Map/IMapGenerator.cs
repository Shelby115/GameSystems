
namespace GameSystems.Map
{
    public interface IMapGenerator
    {
        IDictionary<MapPosition, MapTile> GenerateMap(int width, int height, int depth);
    }
}