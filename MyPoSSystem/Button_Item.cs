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

namespace MyPoSSystem
{
    // A button with Id
    public class ButtonWithId : Button
    {
        public int Id { get; }

        public ButtonWithId(int id) : base()
        {
            Id = id;
        }
    }
}
