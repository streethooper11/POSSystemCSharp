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
    public class SessionDBJson : SessionDB
    {
        protected override void SetAccountFromDB()
        {
            AccountDictionary = JsonSerializer.Deserialize<Dictionary<int, Account>>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.AccountPath))
                );
            AccountChanged = false;
        }

        protected override void SetItemMainFromDB()
        {
            ItemMainDictionary = JsonSerializer.Deserialize<Dictionary<int, Item_Main>>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.ItemMainPath))
                );
            ItemMainChanged = false;
        }

        protected override void SetItemOptionFromDB()
        {
            ItemOptionDictionary = JsonSerializer.Deserialize<Dictionary<int, Item_Option>>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.ItemOptionPath))
                );
            ItemOptionChanged = false;
        }

        protected override void SetMenuOptionFromDB()
        {
            MenuOptionDictionary = JsonSerializer.Deserialize<Dictionary<int, Menu_Option>>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.MenuOptionPath))
                );
            MenuOptionChanged = false;
        }

        protected override void SetTopGroupFromDB()
        {
            TopGroup = JsonSerializer.Deserialize<TopGroup>
                (
                    JSonCrypto.DecryptJson(File.ReadAllBytes(FilePathConst.TopGroupPath))
                );
            TopGroupChanged = false;
        }

        protected override void SaveAccountToDB()
        {
            if (AccountChanged)
            {
                File.WriteAllBytes
                    (
                        FilePathConst.AccountPath,
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

        protected override void SaveItemMainToDB()
        {
            if (ItemMainChanged)
            {
                File.WriteAllBytes
                    (
                        FilePathConst.ItemMainPath,
                        JSonCrypto.EncryptJson
                            (
                                JsonSerializer.Serialize
                                    (
                                        ItemMainDictionary,
                                        new JsonSerializerOptions { WriteIndented = true }
                                    )

                            )
                    );
            }
        }

        protected override void SaveItemOptionToDB()
        {
            if (ItemOptionChanged)
            {
                File.WriteAllBytes
                    (
                        FilePathConst.ItemOptionPath,
                        JSonCrypto.EncryptJson
                            (
                                JsonSerializer.Serialize
                                    (
                                        ItemOptionDictionary,
                                        new JsonSerializerOptions { WriteIndented = true }
                                    )

                            )
                    );
            }
        }

        protected override void SaveMenuOptionToDB()
        {
            if (MenuOptionChanged)
            {
                File.WriteAllBytes
                    (
                        FilePathConst.MenuOptionPath,
                        JSonCrypto.EncryptJson
                            (
                                JsonSerializer.Serialize
                                    (
                                        MenuOptionDictionary,
                                        new JsonSerializerOptions { WriteIndented = true }
                                    )

                            )
                    );
            }
        }

        protected override void SaveTopGroupToDB()
        {
            if (TopGroupChanged)
            {
                File.WriteAllBytes
                    (
                        FilePathConst.TopGroupPath,
                        JSonCrypto.EncryptJson
                            (
                                JsonSerializer.Serialize
                                    (
                                        TopGroup,
                                        new JsonSerializerOptions { WriteIndented = true }
                                    )

                            )
                    );
            }
        }
    }
}
