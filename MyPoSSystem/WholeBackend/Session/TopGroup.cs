using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Session
{
    public class TopGroup
    {
        // key is button ID, value is itemGroup ID
        private Dictionary<int, int> _itemGroups;
        public Dictionary<int, int> ItemGroups => _itemGroups;

        public void AddItemGroupToTopGroup(int buttonId, int itemGroupId)
        {
            _itemGroups[buttonId] = itemGroupId;
        }

        public void DeleteItemGroupFromTopGroup(int buttonId)
        {
            _itemGroups.Remove(buttonId);
        }
    }
}
