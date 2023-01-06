using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using MyPoSSystem.Constants;
using MyPoSSystem.WholeBackend.Security;
using MyPoSSystem.WholeBackend.Session;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    public abstract class SessionDB
    {
        public Dictionary<int, Item_Main>? AllItemMain { get; protected set; } // key is Item_Main ID
        public Dictionary<int, Item_Option>? AllItemOption { get; protected set; } // key is Item_Option ID
        public Dictionary<int, Menu_Main>? AllMenuMain { get; protected set; } // key is Menu_Main ID
        public Dictionary<int, Menu_Option>? AllMenuOption { get; protected set; } // key is Menu_Option ID
        public Account[]? Accounts { get; protected set; } // index is button ID, which is also account ID; Unassign is Deletion of account
        public int[]? AssignedItemMain { get; protected set; } // index is button ID, element is Item_Main ID
        public int[]? AssignedItemOption { get; protected set; } // index is button ID, element is Item_Option ID
        public int[]? AssignedMenuMain { get; protected set; } // index is button ID, element is Menu_Main ID
        public int[]? AssignedMenuOption { get; protected set; } // index is button ID, element is Menu_Option ID
        public Settings? Settings { get; protected set; }

        protected void SetSessionFromDB()
        {
            if (!Directory.Exists(FilePathConst.DBFolder))
            {
                Directory.CreateDirectory(FilePathConst.DBFolder);
            }

            AllItemMain = SetDataFromDB<Dictionary<int, Item_Main>>(FilePathConst.AllItemMainPath);
            AllItemOption = SetDataFromDB<Dictionary<int, Item_Option>>(FilePathConst.AllItemOptionPath);
            AllMenuMain = SetDataFromDB<Dictionary<int, Menu_Main>>(FilePathConst.AllMenuMainPath);
            AllMenuOption = SetDataFromDB<Dictionary<int, Menu_Option>>(FilePathConst.AllMenuOptionPath);

            Accounts = SetDataFromDB<Account>(FilePathConst.AccountPath, SettingConst.MaxAccountButtonNo);

            AssignedItemMain = SetDataFromDB(FilePathConst.AssignedItemMainPath, SettingConst.MaxItemMainButtonNo);
            AssignedItemOption = SetDataFromDB(FilePathConst.AssignedItemOptionPath, SettingConst.MaxItemOptionButtonNo);
            AssignedMenuMain = SetDataFromDB(FilePathConst.AssignedMenuMainPath, SettingConst.MaxMenuMainButtonNo);
            AssignedMenuOption = SetDataFromDB(FilePathConst.AssignedMenuOptionPath, SettingConst.MaxMenuOptionButtonNo);

            Settings = SetDataFromDB<Settings>(FilePathConst.SettingsPath);

            // work on orders later
        }

        protected void SaveSessionToDB()
        {
            SaveDataToDB(FilePathConst.AllItemMainPath, AllItemMain);
            SaveDataToDB(FilePathConst.AllItemOptionPath, AllItemOption);
            SaveDataToDB(FilePathConst.AllMenuMainPath, AllMenuMain);
            SaveDataToDB(FilePathConst.AllMenuOptionPath, AllMenuOption);

            SaveDataToDB(FilePathConst.AccountPath, Accounts);

            SaveDataToDB(FilePathConst.AssignedItemMainPath, AssignedItemMain);
            SaveDataToDB(FilePathConst.AssignedItemOptionPath, AssignedItemOption);
            SaveDataToDB(FilePathConst.AssignedMenuMainPath, AssignedMenuMain);
            SaveDataToDB(FilePathConst.AssignedMenuOptionPath, AssignedMenuOption);

            SaveDataToDB(FilePathConst.SettingsPath, Settings);
        }

        // Add Item
        public void Add<V>(Dictionary<int, V> dictionary, V value)
        {
            dictionary[dictionary.Count] = value;
        }

        // Add relationship
        public void Add<T>(T[] array, int index, T element)
        {
            array[index] = element;
        }

        // usually used when deleting an item; delete all relationships then delete the item itself; rearrange after
        public void Delete<V>(Dictionary<int, V> allDict, int[] assignArray, int key)
        {
            // delete all assigned relationship
            for (int i = 0; i < assignArray.Length; i++)
            {
                if (assignArray[i] == key)
                {
                    assignArray[i] = SettingConst.NoAssignedEntityId;
                }
            }

            allDict.Remove(key);
            RearrangeId(allDict, assignArray, key + 1);
        }

        // Delete relationship (usually used for buttons)
        public void Delete(int[] array, int index)
        {
            array[index] = SettingConst.NoAssignedEntityId;
        }

        // Delete relationship (usually used for buttons)
        public void Delete<T>(T?[] array, int index) where T : class
        {
            array[index] = null;
        }

        // Move relationship (usually used for buttons)
        public void Move(int[] array, int oldKey, int newKey, int value)
        {
            Add(array, newKey, value);
            Delete(array, oldKey);
        }

        // Move relationship (usually used for buttons)
        public void Move<T>(T?[] array, int oldKey, int newKey, T value) where T : class
        {
            Add(array, newKey, value);
            Delete(array, oldKey);
        }

        private void RearrangeId<V>(Dictionary<int,V> allDict, int[] assignArray, int index)
        {
            int dictSize = allDict.Count;

            for (int i = 0; i < assignArray.Length; i++)
            {
                if (assignArray[i] >= index)
                {
                    assignArray[i]--;
                }
            }

            while (index < dictSize)
            {
                allDict[index - 1] = allDict[index];
                allDict.Remove(index);

                index++;
            }
        }

        protected abstract T SetDataFromDB<T>(string filePath) where T : new();
        protected abstract T[] SetDataFromDB<T>(string filePath, int length) where T : class;
        protected abstract int[] SetDataFromDB(string filePath, int length);
        protected abstract void SaveDataToDB<T>(string filePath, T obj);
    }
}
