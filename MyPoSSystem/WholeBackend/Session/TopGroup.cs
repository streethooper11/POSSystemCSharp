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
        // key is button ID, value is menu ID
        private Dictionary<int, int> _assignedMenus;
        public Dictionary<int, int> AssignedMenus => _assignedMenus;

        public TopGroup() 
        {
            _assignedMenus = new Dictionary<int, int>();
        }

        public TopGroup(Dictionary<int, int> assignedMenus)
        {
            _assignedMenus = assignedMenus;
        }

        public void AddMenuToTopGroup(int buttonId, int menuId)
        {
            _assignedMenus[buttonId] = menuId;
        }

        public void DeleteItemGroupFromTopGroup(int buttonId)
        {
            _assignedMenus.Remove(buttonId);
        }
    }
}
