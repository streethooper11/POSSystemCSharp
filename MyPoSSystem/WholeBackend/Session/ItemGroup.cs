using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Session
{
    public class ItemGroup
    {
        private string _name;
        public string Name => _name;

        // key is button ID, value is item ID
        private Dictionary<int, int> _items;
        public Dictionary<int, int> Items => _items;

        public ItemGroup(string name)
        {
            _name = name;
            _items = new Dictionary<int, int>();
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
