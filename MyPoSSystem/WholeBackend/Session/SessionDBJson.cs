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

        protected override T SetDataFromDB<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                return _jsonWorker.ReadDataFromDB<T>(filePath);
            }

            File.Create(filePath).Close();
            return new T();
        }

        protected override T[] SetDataFromDB<T>(string filePath, int length)
        {
            if (File.Exists(filePath))
            {
                return _jsonWorker.ReadDataFromDB<T>(filePath, length);
            }

            File.Create(filePath).Close();
            T[] array = new T[length];
            SaveDataToDB(filePath, array);

            return array;
        }

        protected override int[] SetDataFromDB(string filePath, int length)
        {
            if (File.Exists(filePath))
            {
                return _jsonWorker.ReadDataFromDB<int>(filePath, length);
            }

            File.Create(filePath).Close();
            int[] array = new int[length];
            Array.Fill(array, SettingConst.NoAssignedEntityId);
            SaveDataToDB(filePath, array);

            return array;
        }

        protected override void SaveDataToDB<T>(string filePath, T obj)
        {
            _jsonWorker.SaveDataToDBFile(filePath, obj);
        }
    }
}
