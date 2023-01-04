using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.Constants;
using MyPoSSystem.WholeBackend.Abstracts;
using MyPoSSystem.WholeBackend.Security;

namespace MyPoSSystem.WholeBackend.Session
{
    public class SessionDB
    {
        private static Dictionary<int, Account>? AccountDictionary;

        public static void SetSessionFromDB()
        {
            SetAccounts();
        }

        public static void SaveSessionToDB()
        {
            SaveAccounts();
        }

        private static void SetAccounts()
        {
            AccountDictionary = JsonSerializer.Deserialize<Dictionary<int, Account>>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.AccountsPath))
                );
        }

        private static void SaveAccounts()
        {
            File.WriteAllBytes
                (
                    FilePathConst.AccountsPath,
                    JSonCrypto.EncryptJson
                        (
                            JsonSerializer.Serialize
                                (
                                    AccountDictionary,
                                    new JsonSerializerOptions { WriteIndented = true }
                                )

                        )
                );
        }
    }
}
