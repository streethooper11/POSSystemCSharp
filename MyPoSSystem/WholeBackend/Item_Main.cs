using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend
{
    /**
     * Main item is an item that can be sold separately
     * It may contain an option menu that you can choose
     */
    public class Item_Main : Item
    {
        private Menu_Option? _optionMenu;
        private string _category;

        public Item_Main(string name, decimal price, string category) : base(name, price)
        {
            _category = category;
            _optionMenu = null;
        }

        public Item_Main(string name, decimal price, decimal itemTaxPercentage, string category) : base(name, price, itemTaxPercentage)
        {
            _category = category;
            _optionMenu = null;
        }

        public Item_Main(string name, decimal price, string category, Menu_Option optionMenu) : this(name, price, category)
        {
            _optionMenu = optionMenu;
        }

        public Item_Main(string name, decimal price, decimal itemTaxPercentage, string category, Menu_Option optionMenu) : this(name, price, itemTaxPercentage, category)
        {
            _optionMenu = optionMenu;
        }
    }
}
