using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of an item group which contains name
    public abstract class ItemGroup
    {
        private string _name;
        public string Name => _name;

        public ItemGroup(string name)
        {
            _name = name;
        }
    }
}
