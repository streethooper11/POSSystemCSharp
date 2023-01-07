using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.Constants;
using MyPoSSystem.DataStruct;

namespace MyPoSSystem.Sale
{
    // Abstract representation of a menu which contains name
    public abstract class Menu : INotifyPropertyChanged
    {
        private string _name;
        private MyObservableCollection<MyInt> _items; // item ID

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyObservableCollection<MyInt> Items
        {
            get { return _items; }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Menu(string name)
        {
            _name = name;
            _items = new MyObservableCollection<MyInt>();
        }

        protected Menu(string name, MyObservableCollection<MyInt> items)
        {
            _name = name;
            _items = items;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void AddItemToGroup(int buttonId, MyInt itemId)
        {
            Items[buttonId] = itemId;
        }

        public void DeleteItemFromGroup(int buttonId)
        {
            Items[buttonId] = SettingConst.NoAssignedEntityId;
        }

        public void ChangeMenuName(string name)
        {
            Name = name;
        }
    }
}
