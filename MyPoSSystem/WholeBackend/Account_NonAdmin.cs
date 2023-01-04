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
    public class Account_NonAdmin : Account
    {
        public Account_NonAdmin(string name, int pin) : base(name, pin)
        {
        }
    }
}
