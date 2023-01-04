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
        protected Dictionary<int, Account>? AccountDictionary;
        protected bool AccountChanged;

        protected Dictionary<int, Item_Main>? ItemMainDictionary;
        protected bool ItemMainChanged;

        protected Dictionary<int, Item_Option>? ItemOptionDictionary;
        protected bool ItemOptionChanged;

        protected Dictionary<int, Menu_Option>? MenuOptionDictionary;
        protected bool MenuOptionChanged;

        protected TopGroup? TopGroup;
        protected bool TopGroupChanged;

        public void SetSessionFromDB()
        {
            SetAccountFromDB();
            SetItemMainFromDB();
            SetItemOptionFromDB();
            SetMenuOptionFromDB();
            SetTopGroupFromDB();
        }

        public void SaveSessionToDB()
        {
            SaveAccountToDB();
            SaveItemMainToDB();
            SaveItemOptionToDB();
            SaveMenuOptionToDB();
            SaveTopGroupToDB();
        }

        protected abstract void SetAccountFromDB();
        protected abstract void SetItemMainFromDB();
        protected abstract void SetItemOptionFromDB();
        protected abstract void SetMenuOptionFromDB();
        protected abstract void SetTopGroupFromDB();
        protected abstract void SaveAccountToDB();
        protected abstract void SaveItemMainToDB();
        protected abstract void SaveItemOptionToDB();
        protected abstract void SaveMenuOptionToDB();
        protected abstract void SaveTopGroupToDB();
    }
}
