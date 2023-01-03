using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of an item with name and price
    // Source for INotifyPropertyChanged:
    // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
    public abstract class Item : INotifyPropertyChanged
    {
        private string _name;
        private decimal _price;

        // key is button ID, value is item ID
        private Dictionary<int, int> _items;
        public Dictionary<int, int> Items => _items;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected Item(string name, decimal price)
        {
            _name = name;
            _price = price;
            _items = new Dictionary<int, int>();
        }

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

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void AddItemToGroup(int buttonId, int itemId)
        {
            _items[buttonId] = itemId;
        }

        public void DeleteItemFromGroup(int buttonId)
        {
            _items.Remove(buttonId);
        }
    }
}
