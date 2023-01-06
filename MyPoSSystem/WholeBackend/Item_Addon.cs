using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend
{
    public class Item_Option : Item
    {
        public Item_Option(string name, decimal price, string category) : base(name, price, category)
        {
        }

        public Item_Option(string name, decimal price, decimal itemTaxPercentage, string category) : base(name, price, itemTaxPercentage, category)
        {
        }
    }
}
