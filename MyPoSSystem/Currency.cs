using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem
{
    public class Currency
    {
        public string Name { get; }

        public string Symbol { get; }

        public Currency(string name, string symbol) 
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
