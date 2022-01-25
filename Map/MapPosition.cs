namespace GameSystems.Map
{
    public struct MapPosition
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public MapPosition(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public int DistanceFrom(MapPosition mapPosition)
        {
            var xDiff = mapPosition.X - X;
            var yDiff = mapPosition.Y - Y;
            return Convert.ToInt32(Math.Sqrt(xDiff * xDiff + yDiff * yDiff));
        }
    }
}