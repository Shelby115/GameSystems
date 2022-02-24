namespace GameSystems.Map
{
    public struct MapTile
    {
        public MapPosition Position { get; }
        public string Type { get; }

        public MapTile(MapPosition position, string type)
        {
            Position = position;
            Type = type;
        }
    }
}