namespace GameSystems.Map
{
    public struct MapPositionInfo
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public MapPositionInfo(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public int DistanceFrom(MapPositionInfo mapPosition)
        {
            var xDiff = mapPosition.X - X;
            var yDiff = mapPosition.Y - Y;
            return Convert.ToInt32(Math.Sqrt(xDiff * xDiff + yDiff * yDiff));
        }
    }
}