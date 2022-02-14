using System.Collections.Concurrent;

namespace GameSystems.Character
{
    public class Attributes
    {
        private readonly ConcurrentDictionary<string, int> AttributeCollection;

        public int this[string nameOfAttribute]
        {
            get => AttributeCollection.GetOrAdd(nameOfAttribute, 0);
            set => AttributeCollection.AddOrUpdate(nameOfAttribute, value, (string _, int _) => value);
        }

        public Attributes()
        {
            AttributeCollection = new ConcurrentDictionary<string, int>();
        }

        public Attributes(IEnumerable<KeyValuePair<string, int>> attributes)
        {
            AttributeCollection = new ConcurrentDictionary<string,int>(attributes);
        }
    }
}