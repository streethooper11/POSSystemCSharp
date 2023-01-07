using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.DataStruct;

namespace MyPoSSystem.Backend
{
    public abstract class DBWorker
    {
        public void CreateDBFile(string filePath)
        {
            File.CreateText(filePath).Close();
        }

        public void DeleteDBFile(string filePath)
        {
            File.Delete(filePath);
        }

        public abstract void SaveDataToDBFile<T>(string filePath, T obj);
        public abstract T ReadDataFromDB<T>(string filePath) where T : new();
        public abstract MyObservableCollection<T> ReadDataFromDB<T>(string filePath, int length) where T : INotifyPropertyChanged;
    }
}
