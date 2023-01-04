using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.Sale.Hardware_Control;
using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend.Session
{
    public class Settings
    {
        private Currency _currency;
        private string _language;
        private decimal _defaultTaxPercent;
        private HashSet<Printer> _printers;
    }
}
