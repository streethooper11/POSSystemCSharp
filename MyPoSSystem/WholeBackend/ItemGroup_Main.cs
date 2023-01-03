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
    public class ItemGroup_Main : ItemGroup
    {
        public ItemGroup_Main(string name) : base(name)
        {
        }
    }
}
