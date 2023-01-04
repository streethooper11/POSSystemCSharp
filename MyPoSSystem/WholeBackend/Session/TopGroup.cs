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
        private Dictionary<int, int> _menus;
        public Dictionary<int, int> Menus => _menus;

        public TopGroup() 
        {
            _menus = new Dictionary<int, int>();
        }

        public TopGroup(Dictionary<int, int> menus)
        {
            _menus = menus;
        }

        public void AddMenuToTopGroup(int buttonId, int menuId)
        {
            _menus[buttonId] = menuId;
        }

        public void DeleteItemGroupFromTopGroup(int buttonId)
        {
            _menus.Remove(buttonId);
        }
    }
}
