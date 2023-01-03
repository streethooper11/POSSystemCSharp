using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of an account with username and PIN
    public abstract class Account
    {
        private string _name;
        private int _PIN;

        protected Account(string name, int pin)
        {
            _name = name;
            _PIN = pin;
        }
    }
}
