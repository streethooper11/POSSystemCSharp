using System;
using System.Collections.Generic;
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
        public override void SaveDataToDBFile(string filePath, object? obj)
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

        public override object ReadDataFromDB(string filePath)
        {
            byte[] json = File.ReadAllBytes(filePath);

            if (json.Length == 0)
            {
                return new object();
            }

            return JsonSerializer.Deserialize<object>(JSonCrypto.DecryptJson(json));
        }
    }
}
