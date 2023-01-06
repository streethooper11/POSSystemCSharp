using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;
using MyPoSSystem.WholeBackend.Security;
using MyPoSSystem.WholeBackend.Session;

namespace MyPoSSystem.WholeBackend
{
    public class JsonWorker : DBWorker
    {
        public override void SaveDataToDBFile<T>(string filePath, T obj)
        {
            File.WriteAllBytes
                (
                    filePath,
                    JSonCrypto.EncryptJson
                        (
                            JsonSerializer.Serialize
                                (
                                    obj,
                                    new JsonSerializerOptions { WriteIndented = true }
                                )

                        )
                );
        }

        public override T ReadDataFromDB<T>(string filePath)
        {
            byte[] json = File.ReadAllBytes(filePath);

            if (json.Length == 0)
            {
                return new T();
            }

            return JsonSerializer.Deserialize<T>(JSonCrypto.DecryptJson(json));
        }

        public override ObservableCollection<T> ReadDataFromDB<T>(string filePath, int length)
        {
            byte[] json = File.ReadAllBytes(filePath);

            if (json.Length == 0)
            {
                return new ObservableCollection<T>();
            }

            return JsonSerializer.Deserialize<ObservableCollection<T>>(JSonCrypto.DecryptJson(json));
        }
    }
}
