using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend
{
    public class JsonWorker : DBWorker
    {
        public override void SaveDictionaryToDBFile<K, V>(string filePath, Dictionary<K, V> keyValuePairs)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(keyValuePairs, new JsonSerializerOptions { WriteIndented = true }));
        }

        public override Dictionary<K, V> ReadDictionaryFromDB<K, V>(string filePath)
        {
            string json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new Dictionary<K, V>();
            }

            return new Dictionary<K, V>(JsonSerializer.Deserialize<Dictionary<K, V>>(json));
        }
    }
}
