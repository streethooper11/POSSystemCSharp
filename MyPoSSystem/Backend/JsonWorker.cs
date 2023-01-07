using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.DataStruct;
using MyPoSSystem.Security;

namespace MyPoSSystem.Backend
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

        public override MyObservableCollection<T> ReadDataFromDB<T>(string filePath, int length)
        {
            byte[] json = File.ReadAllBytes(filePath);

            if (json.Length == 0)
            {
                return new MyObservableCollection<T>();
            }

            return JsonSerializer.Deserialize<MyObservableCollection<T>>(JSonCrypto.DecryptJson(json));
        }
    }
}
