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
        }

        protected override void SetAllItemMainFromDB()
        {
            AllItemMainDictionary = (Dictionary<int, Item_Main>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllItemMainPath);
        }

        protected override void SetAllItemOptionFromDB()
        {
            AllItemOptionDictionary = (Dictionary<int, Item_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllItemOptionPath);
        }

        protected override void SetAllMenuMainFromDB()
        {
            AllMenuMainDictionary = (Dictionary<int, Menu_Main>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllMenuMainPath);
        }

        protected override void SetAllMenuOptionFromDB()
        {
            AllMenuOptionDictionary = (Dictionary<int, Menu_Option>?)_jsonWorker.ReadDataFromDB(FilePathConst.AllMenuOptionPath);
        }

        protected override void SetAssignedItemMainFromDB()
        {
            AssignedItemMainDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedItemMainPath);
        }

        protected override void SetAssignedItemOptionFromDB()
        {
            AssignedItemOptionDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedItemOptionPath);
        }

        protected override void SetAssignedMenuMainFromDB()
        {
            AssignedMenuMainDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedMenuMainPath);
        }

        protected override void SetAssignedMenuOptionFromDB()
        {
            AssignedMenuOptionDictionary = (Dictionary<int, int>?)_jsonWorker.ReadDataFromDB(FilePathConst.AssignedMenuOptionPath);
        }

        protected override void SetSettingsFromDB()
        {
            Settings = (Settings?)_jsonWorker.ReadDataFromDB(FilePathConst.SettingsPath);
        }

        protected override void SaveAccountToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AccountPath, AccountDictionary);
        }

        protected override void SaveAllItemMainToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AllItemMainPath, AllItemMainDictionary);
        }

        protected override void SaveAllItemOptionToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AllItemOptionPath, AllItemOptionDictionary);
        }

        protected override void SaveAllMenuMainToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AllMenuMainPath, AllMenuMainDictionary);
        }

        protected override void SaveAllMenuOptionToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AllMenuOptionPath, AllMenuOptionDictionary);
        }

        protected override void SaveAssignedItemMainToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedItemMainPath, AssignedItemMainDictionary);
        }

        protected override void SaveAssignedItemOptionToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedItemOptionPath, AssignedItemOptionDictionary);
        }

        protected override void SaveAssignedMenuMainToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedMenuMainPath, AssignedMenuMainDictionary);
        }

        protected override void SaveAssignedMenuOptionToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.AssignedMenuOptionPath, AssignedMenuOptionDictionary);
        }

        protected override void SaveSettingsToDB()
        {
            _jsonWorker.SaveDataToDBFile(FilePathConst.SettingsPath, Settings);
        }
    }
}
