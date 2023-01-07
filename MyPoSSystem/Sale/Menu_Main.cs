using MyPoSSystem.WholeBackend.DataStruct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Sale
{
    // A menu that contains a list of main items
    public class Menu_Main : Menu
    {
        public Menu_Main(string name) : base(name)
        {
        }

        public Menu_Main(string name, MyObservableCollection<MyInt> items) : base(name, items)
        {
        }
    }
}
