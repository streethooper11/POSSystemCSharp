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
        private readonly JsonWorker _jsonWorker;

        public SessionDBJson() : base() 
        { 
            _jsonWorker = new JsonWorker();
        }

        protected override void SetAccountFromDB()
        {
            AccountDictionary = (Dictionary<int, Account>?)_jsonWorker.ReadDataFromDB(FilePathConst.AccountPath);
            AccountChanged = false;
        }

        protected override void SetItemMainFromDB()
        {
            ItemMainDictionary = (Dictionary<int, Item_Main>?)_jsonWorker.ReadDataFromDB(FilePathConst.ItemMainPath);
            ItemMainChanged = false;
        }

        protected override void SetItemOptionFromDB()
        {
            ItemOptionDictionary = (Dictionary<int, Item_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.ItemOptionPath); 
            ItemOptionChanged = false;
        }

        protected override void SetMenuOptionFromDB()
        {
            MenuOptionDictionary = (Dictionary<int, Menu_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.MenuOptionPath);
            MenuOptionChanged = false;
        }

        protected override void SetTopGroupFromDB()
        {
            TopGroup = (TopGroup?)_jsonWorker.ReadDataFromDB(FilePathConst.TopGroupPath);
            TopGroupChanged = false;
        }

        protected override void SetSettingsFromDB()
        {
            Settings = (Settings?)_jsonWorker.ReadDataFromDB(FilePathConst.SettingsPath);
            SettingsChanged = false;
        }

        protected override void SaveAccountToDB()
        {
            if (AccountChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AccountPath, AccountDictionary);
            }
        }

        protected override void SaveItemMainToDB()
        {
            if (ItemMainChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.ItemMainPath, ItemMainDictionary);
            }
        }

        protected override void SaveItemOptionToDB()
        {
            if (ItemOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.ItemOptionPath, ItemOptionDictionary);
            }
        }

        protected override void SaveMenuOptionToDB()
        {
            if (MenuOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.MenuOptionPath, MenuOptionDictionary);
            }
        }

        protected override void SaveTopGroupToDB()
        {
            if (TopGroupChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.TopGroupPath, TopGroup);
            }
        }

        protected override void SaveSettingsToDB()
        {
            if (SettingsChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.SettingsPath, Settings);
            }
        }
    }
}
