namespace GameSystems.Map
{
    public interface IMap
    {
        public int Width { get; }
        public int Depth { get; }
        public int Height { get; }
        public MapPosition[,,] Position { get; }

        (float x, float y, float z) ConvertFromMapPosition(MapPosition mapPosition);
        MapPosition ConvertToMapPosition(float x, float y, float z);
    }
}