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
    // Abstract representation of an account with username and PIN
    public class Account_Admin : Account
    {
        public Account_Admin(string name, int pin) : base(name, pin)
        {
        }
    }
}
