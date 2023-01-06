using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.Constants;
using MyPoSSystem.WholeBackend.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPoSSystem.WholeBackend.Session
{
    public class SessionDBJson : SessionDB
    {
        private readonly JsonWorker _jsonWorker;

        public SessionDBJson() : base() 
        { 
            _jsonWorker = new JsonWorker();
            SetSessionFromDB();
        }

        protected override void SetDataFromDB<V>(string filePath, Dictionary<int, V> dictionary)
        {
            if (File.Exists(filePath))
            {
                dictionary = _jsonWorker.ReadDataFromDB<Dictionary<int, V>>(filePath);
            }
            else
            {
                File.Create(filePath).Close();
                dictionary = new Dictionary<int, V>();
                SaveDataToDB(filePath, dictionary);
            }
        }

        protected override void SetDataFromDB<T>(string filePath, T[]? array, int length)
        {
            if (File.Exists(filePath))
            {
                array = _jsonWorker.ReadDataFromDB<T>(filePath, length);
            }
            else
            {
                File.Create(filePath).Close();
                array = new T[length];
                SaveDataToDB(filePath, array);
            }
        }

        protected override void SetDataFromDB(string filePath, int[]? array, int length)
        {
            if (File.Exists(filePath))
            {
                array = _jsonWorker.ReadDataFromDB<int>(filePath, length);
            }
            else
            {
                File.Create(filePath).Close();
                array = new int[length];
                Array.Fill(array, SettingConst.NoAssignedEntityId);
                SaveDataToDB(filePath, array);
            }
        }

        protected override void SetDataFromDB(string filePath, Settings? obj)
        {
            if (File.Exists(filePath))
            {
                obj = _jsonWorker.ReadDataFromDB<Settings>(filePath);
            }
            else
            {
                File.Create(filePath).Close();
                obj = new Settings();
                SaveDataToDB(filePath, obj);
            }
        }

        protected override void SaveDataToDB<T>(string filePath, T obj)
        {
            _jsonWorker.SaveDataToDBFile(filePath, obj);
        }
    }
}
