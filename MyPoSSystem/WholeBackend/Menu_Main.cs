using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // A menu that contains a list of main items
    public class Menu_Main : Menu
    {
        public Menu_Main(string name) : base(name)
        {
        }

        public Menu_Main(string name, Dictionary<int, int> items) : base(name, items)
        {
        }
    }
}
