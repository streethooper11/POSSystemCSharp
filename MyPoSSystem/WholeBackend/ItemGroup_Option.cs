using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // An item group that contains the list of main menus
    public class ItemGroup_Option : ItemGroup
    {
        public ItemGroup_Option(string name) : base(name)
        {
        }
    }
}
