using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.Constants;
using MyPoSSystem.WholeBackend.Abstracts;

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

        protected override void SetAllItemMainFromDB()
        {
            AllItemMainDictionary = (Dictionary<int, Item_Main>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllItemMainPath);
            AllItemMainChanged = false;
        }

        protected override void SetAllItemOptionFromDB()
        {
            AllItemOptionDictionary = (Dictionary<int, Item_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllItemOptionPath);
            AllItemOptionChanged = false;
        }

        protected override void SetAllMenuMainFromDB()
        {
            AllMenuMainDictionary = (Dictionary<int, Menu_Main>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllMenuMainPath);
            AllMenuMainChanged = false;
        }

        protected override void SetAllMenuOptionFromDB()
        {
            AllMenuOptionDictionary = (Dictionary<int, Menu_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllMenuOptionPath);
            AllMenuOptionChanged = false;
        }

        protected override void SetAssignedItemMainFromDB()
        {
            AssignedItemMainDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedItemMainPath);
            AssignedItemMainChanged = false;
        }

        protected override void SetAssignedItemOptionFromDB()
        {
            AssignedItemOptionDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedItemOptionPath); 
            AssignedItemOptionChanged = false;
        }

        protected override void SetAssignedMenuOptionFromDB()
        {
            AssignedMenuOptionDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedMenuOptionPath);
            AssignedMenuOptionChanged = false;
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

        protected override void SaveAllItemMainToDB()
        {
            if (AllItemMainChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AllItemMainPath, AllItemMainDictionary);
            }
        }

        protected override void SaveAllItemOptionToDB()
        {
            if (AllItemOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AllItemOptionPath, AllItemOptionDictionary);
            }
        }

        protected override void SaveAllMenuMainToDB()
        {
            if (AllMenuMainChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AllMenuMainPath, AllMenuMainDictionary);
            }
        }

        protected override void SaveAllMenuOptionToDB()
        {
            if (AllMenuOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AllMenuOptionPath, AllMenuOptionDictionary);
            }
        }

        protected override void SaveAssignedItemMainToDB()
        {
            if (AssignedItemMainChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedItemMainPath, AssignedItemMainDictionary);
            }
        }

        protected override void SaveAssignedItemOptionToDB()
        {
            if (AssignedItemOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedItemOptionPath, AssignedItemOptionDictionary);
            }
        }

        protected override void SaveAssignedMenuOptionToDB()
        {
            if (AssignedMenuOptionChanged)
            {
                _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedMenuOptionPath, AssignedMenuOptionDictionary);
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
