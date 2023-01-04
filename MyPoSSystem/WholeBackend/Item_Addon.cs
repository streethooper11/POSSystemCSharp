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
        public Item_Option(string name, decimal price) : base(name, price)
        {
        }

        public Item_Option(string name, decimal price, decimal itemTaxPercentage) : base(name, price, itemTaxPercentage)
        {
        }
    }
}
