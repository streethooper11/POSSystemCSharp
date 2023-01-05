using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.Constants;
using MyPoSSystem.Sale.Hardware_Control;

namespace MyPoSSystem.WholeBackend.Session
{
    public class Settings
    {
        public Currency _currency { get; set; }
        public string _language { get; set; }
        public decimal _defaultTaxPercent { get; set; }
        public HashSet<Printer> _printers { get; set; }

        public Settings()
        {
            // default
            _currency = new Currency("CAD", "$");
            _language = "English";
            _defaultTaxPercent = SettingConst.DefaultTax;
            _printers = new HashSet<Printer>();
        }

        public Settings(Currency currency, string language, decimal defaultTaxPercent, HashSet<Printer> printers)
        {
            _currency = currency;
            _language = language;
            _defaultTaxPercent = defaultTaxPercent;
            _printers = printers;
        }
    }
}
