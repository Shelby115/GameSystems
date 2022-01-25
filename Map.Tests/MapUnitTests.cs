using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameSystems.Map.Tests
{
    [TestClass]
    public class MapUnitTests
    {
        [TestMethod]
        public void Map_ConvertFromMapPosition_Standard()
        {
            var pos = new MapPosition(2, 2, 2);
            var map = new Map(20, 20, 20, 1.0f, 1.0f, 1.0f);
            var expected = (x: 2.0f, y: 2.0f, z: 2.0f);
            var actual = map.ConvertFromMapPosition(pos);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map_ConvertToMapPosition_Standard()
        {
            var (x, y, z) = (2.0f, 2.0f, 2.0f);
            var map = new Map(20, 20, 20, 1.0f, 1.0f, 1.0f);
            var expected = new MapPosition(2, 2, 2);
            var actual = map.ConvertToMapPosition(x, y, z);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Map_ConvertFromMapPosition_Obscure()
        {
            var pos = new MapPosition(2, 2, 2);
            var map = new Map(20, 20, 20, 2.0f, 1.3f, 0.75f);
            var expected = (x: 4.0f, y: 2.6f, z: 1.5f);
            var actual = map.ConvertFromMapPosition(pos);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Map_ConvertToMapPosition_Obscure()
        {
            var (x, y, z) = (4.0f, 2.6f, 1.5f);
            var map = new Map(20, 20, 20, 2.0f, 1.3f, 0.75f);
            var expected = new MapPosition(2, 2, 2);
            var actual = map.ConvertToMapPosition(x, y, z);
            Assert.AreEqual(expected, actual);
        }
    }
}