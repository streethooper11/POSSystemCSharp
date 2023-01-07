using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.DataStruct;

namespace MyPoSSystem.Sale
{
    // A menu that contains a list of option items
    public class Menu_Option : Menu
    {
        public Menu_Option(string name) : base(name)
        {
        }

        public Menu_Option(string name, MyObservableCollection<MyInt> items) : base(name, items)
        {
        }
    }
}
