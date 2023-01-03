using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace MyPoSSystem.WholeBackend
{
    // A button with Id
    public class Button_Item : Button
    {
        private int _id;
        public int Id => _id;

        public Button_Item(int id) : base()
        {
            _id = id;
        }
    }
}
