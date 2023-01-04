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
     * Main item is a menu item that can be sold separately
     * It may contain an option item group that you can choose
     */
    public class Item_Main : Item
    {
        private ItemGroup_Option? _optionItemGroup;
        private string _category;

        public Item_Main(string name, decimal price, string category) : base(name, price)
        {
            _category = category;
            _optionItemGroup = null;
        }

        public Item_Main(string name, decimal price, string category, ItemGroup_Option optionItemGroup) : this(name, price, category)
        {
            _optionItemGroup = optionItemGroup;
        }
    }
}
