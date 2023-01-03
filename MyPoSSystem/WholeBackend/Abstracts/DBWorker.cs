using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    public abstract class DBWorker
    {
        public void CreateDBFile(string filePath)
        {
            File.CreateText(filePath).Close();
        }

        public void DeleteDBFile(string filePath)
        {
            File.Delete(filePath);
        }

        public abstract void SaveDictionaryToDBFile<K, V>(string filePath, Dictionary<K, V> keyValuePairs) where K : notnull;
        public abstract Dictionary<K, V> ReadDictionaryFromDB<K, V>(string filePath) where K : notnull;
    }
}
