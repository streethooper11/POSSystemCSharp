using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.Constants;
using MyPoSSystem.WholeBackend.Security;
using MyPoSSystem.WholeBackend.Session;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    public abstract class SessionDB
    {
        protected Dictionary<int, Account>? AccountDictionary; // key is button ID
        protected bool AccountChanged;

        protected Dictionary<int, Item_Main>? AllItemMainDictionary; // key is Item_Main ID
        protected bool AllItemMainChanged;

        protected Dictionary<int, Item_Option>? AllItemOptionDictionary; // key is Item_Option ID
        protected bool AllItemOptionChanged;

        protected Dictionary<int, Menu_Option>? AllMenuOptionDictionary; // key is Menu_Option ID
        protected bool AllMenuOptionChanged;

        protected Dictionary<int, int>? AssignedItemMainDictionary; // key is button ID, value is Item_Main ID
        protected bool AssignedItemMainChanged;

        protected Dictionary<int, int>? AssignedItemOptionDictionary; // key is button ID, value is Item_Option ID
        protected bool AssignedItemOptionChanged;

        protected Dictionary<int, int>? AssignedMenuOptionDictionary; // key is button ID, value is Menu_Option ID
        protected bool AssignedMenuOptionChanged;

        protected TopGroup? TopGroup;
        protected bool TopGroupChanged;

        protected Settings? Settings;
        protected bool SettingsChanged;

        public void SetSessionFromDB()
        {
            SetAccountFromDB();
            SetAssignedItemMainFromDB();
            SetAssignedItemOptionFromDB();
            SetAssignedMenuOptionFromDB();
            SetTopGroupFromDB();
            SetSettingsFromDB();
        }

        public void SaveSessionToDB()
        {
            SaveAccountToDB();
            SaveAssignedItemMainToDB();
            SaveAssignedItemOptionToDB();
            SaveAssignedMenuOptionToDB();
            SaveTopGroupToDB();
            SaveSettingsToDB();
        }

        public void AddAccount(int buttonId, Account account)
        {
            AccountDictionary[buttonId] = account;
        }

        public void RemoveAccount(int buttonId)
        {
            AccountDictionary.Remove(buttonId);
        }

        public void MoveAccount(int oldButtonId, int newButtonId, Account account)
        {
            RemoveAccount(oldButtonId);
            AddAccount(newButtonId, account);
        }

        protected abstract void SetAccountFromDB();
        protected abstract void SetAssignedItemMainFromDB();
        protected abstract void SetAssignedItemOptionFromDB();
        protected abstract void SetAssignedMenuOptionFromDB();
        protected abstract void SetTopGroupFromDB();
        protected abstract void SetSettingsFromDB();
        protected abstract void SaveAccountToDB();
        protected abstract void SaveAssignedItemMainToDB();
        protected abstract void SaveAssignedItemOptionToDB();
        protected abstract void SaveAssignedMenuOptionToDB();
        protected abstract void SaveTopGroupToDB();
        protected abstract void SaveSettingsToDB();
    }
}
