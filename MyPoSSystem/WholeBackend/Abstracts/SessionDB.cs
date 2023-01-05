using System;
using System.Collections.Generic;
using System.Configuration;
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
        public Dictionary<int, Account>? AccountDictionary { get; protected set; } // key is button ID, which is also account ID; Unassign is Deletion of account
        public Dictionary<int,Item_Main>? AllItemMainDictionary { get; protected set; } // key is Item_Main ID
        public Dictionary<int,Item_Option>? AllItemOptionDictionary { get; protected set; } // key is Item_Option ID
        public Dictionary<int,Menu_Main>? AllMenuMainDictionary { get; protected set; } // key is Menu_Main ID
        public Dictionary<int,Menu_Option>? AllMenuOptionDictionary { get; protected set; } // key is Menu_Option ID
        public Dictionary<int,int>? AssignedItemMainDictionary { get; protected set; } // key is button ID, value is Item_Main ID
        public Dictionary<int,int>? AssignedItemOptionDictionary { get; protected set; } // key is button ID, value is Item_Option ID
        public Dictionary<int,int>? AssignedMenuMainDictionary { get; protected set; } // key is button ID, value is Menu_Main ID
        public Dictionary<int,int>? AssignedMenuOptionDictionary { get; protected set; } // key is button ID, value is Menu_Option ID
        public Settings? Settings { get; protected set; }

        public void SetSessionFromDB()
        {
            SetAccountFromDB();
            SetAllItemMainFromDB();
            SetAllItemOptionFromDB();
            SetAllMenuMainFromDB();
            SetAllMenuOptionFromDB();
            SetAssignedItemMainFromDB();
            SetAssignedItemOptionFromDB();
            SetAssignedMenuMainFromDB();
            SetAssignedMenuOptionFromDB();
            SetSettingsFromDB();
        }

        public void SaveSessionToDB()
        {
            SaveAccountToDB();
            SaveAllItemMainToDB();
            SaveAllItemOptionToDB();
            SaveAllMenuMainToDB();
            SaveAllMenuOptionToDB();
            SaveAssignedItemMainToDB();
            SaveAssignedItemOptionToDB();
            SaveAssignedMenuMainToDB();
            SaveAssignedMenuOptionToDB();
            SaveSettingsToDB();
        }

        public void Add<V>(Dictionary<int,V> dictionary, V value)
        {
            dictionary[dictionary.Count] = value;
        }

        public void Add<V>(Dictionary<int, V> dictionary, int key, V value)
        {
            dictionary[key] = value;
        }

        public void Delete<V>(Dictionary<int, V> dictionary, int key)
        {
            dictionary.Remove(key);
        }

        // delete all matching values then delete
        public void Delete<V>(Dictionary<int,V> allDict, Dictionary<int,int> assignDict, int key)
        {
            foreach(var kvp in assignDict)
            {
                if (kvp.Value == key)
                {
                    Delete(assignDict, key);
                }
            }

            allDict.Remove(key);
            RearrangeId(allDict);
        }

        public void Move<V>(Dictionary<int,V> dictionary, int oldKey, int newKey, V value)
        {
            Delete(dictionary, oldKey);
            Add(dictionary, newKey, value);
        }

        private void RearrangeId<V>(Dictionary<int, V> dictionary)
        {
            int i = 0;
            int noKeysChecked = 0;
            int dictSize = dictionary.Count;

            // find the first slot with a key that doesn't exist
            while (noKeysChecked < dictSize)
            {
                if (dictionary.ContainsKey(i))
                {
                    noKeysChecked++;
                    i++;
                }
            }

            // traverse to find an existing key and copy the value over
            while (noKeysChecked < dictSize)
            {
                while (!dictionary.ContainsKey(i))
                {
                    i++;
                }

                dictionary[noKeysChecked] = dictionary[i];
                dictionary.Remove(i);

                noKeysChecked++;
                i++;
            }
        }

        protected abstract void SetAccountFromDB();
        protected abstract void SetAllItemMainFromDB();
        protected abstract void SetAllItemOptionFromDB();
        protected abstract void SetAllMenuMainFromDB();
        protected abstract void SetAllMenuOptionFromDB();
        protected abstract void SetAssignedItemMainFromDB();
        protected abstract void SetAssignedItemOptionFromDB();
        protected abstract void SetAssignedMenuMainFromDB();
        protected abstract void SetAssignedMenuOptionFromDB();
        protected abstract void SetSettingsFromDB();
        protected abstract void SaveAccountToDB();
        protected abstract void SaveAllItemMainToDB();
        protected abstract void SaveAllItemOptionToDB();
        protected abstract void SaveAllMenuMainToDB();
        protected abstract void SaveAllMenuOptionToDB();
        protected abstract void SaveAssignedItemMainToDB();
        protected abstract void SaveAssignedItemOptionToDB();
        protected abstract void SaveAssignedMenuMainToDB();
        protected abstract void SaveAssignedMenuOptionToDB();
        protected abstract void SaveSettingsToDB();
    }
}
