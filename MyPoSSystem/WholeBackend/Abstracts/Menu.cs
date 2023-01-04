using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of a menu which contains name
    public abstract class Menu
    {
        private string _name;
        public string Name => _name;

        // key is button ID, value is item ID
        private Dictionary<int, int> _items;
        public Dictionary<int, int> Items => _items;

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
