using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of a menu which contains name
    public abstract class Menu : INotifyPropertyChanged
    {
        private string _name;
        private Dictionary<int, int> _items; // key is button ID, value is item ID

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

        public Dictionary<int, int> Items
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
            _items = new Dictionary<int, int>();
        }

        protected Menu(string name, Dictionary<int, int> items)
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

        public void AddItemToGroup(int buttonId, int itemId)
        {
            Items[buttonId] = itemId;
        }

        public void DeleteItemFromGroup(int buttonId)
        {
            Items.Remove(buttonId);
        }

        public void ChangeMenuName(string name)
        {
            Name = name;
        }
    }
}
