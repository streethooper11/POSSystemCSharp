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
        // key is button ID, value is itemGroup_Main ID
        private Dictionary<int, int> _itemGroups;
        public Dictionary<int, int> ItemGroups => _itemGroups;

        public TopGroup() 
        {
            _itemGroups = new Dictionary<int, int>();
        }

        public TopGroup(Dictionary<int, int> itemGroups)
        {
            _itemGroups = itemGroups;
        }

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
