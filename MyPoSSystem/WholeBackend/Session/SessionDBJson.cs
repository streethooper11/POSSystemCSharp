using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        protected override ObservableCollection<T> SetDataFromDB<T>(string filePath, int length)
        {
            if (File.Exists(filePath))
            {
                return _jsonWorker.ReadDataFromDB<T>(filePath, length);
            }

            File.Create(filePath).Close();
            ObservableCollection<T> col = new ObservableCollection<T>();

            for (int i = 0; i < length; i++)
            {
                col.Add(null);
            }
            SaveDataToDB(filePath, col);

            return col;
        }

        protected override ObservableCollection<int> SetDataFromDB(string filePath, int length)
        {
            if (File.Exists(filePath))
            {
                return _jsonWorker.ReadDataFromDB<int>(filePath, length);
            }

            File.Create(filePath).Close();
            ObservableCollection<int> col = new ObservableCollection<int>();

            for (int i = 0; i < length; i++)
            {
                col.Add(SettingConst.NoAssignedEntityId);
            }
            SaveDataToDB(filePath, col);

            return col;
        }

        protected override void SaveDataToDB<T>(string filePath, T obj)
        {
            _jsonWorker.SaveDataToDBFile(filePath, obj);
        }
    }
}
