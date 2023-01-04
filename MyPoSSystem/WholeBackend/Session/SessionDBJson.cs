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
