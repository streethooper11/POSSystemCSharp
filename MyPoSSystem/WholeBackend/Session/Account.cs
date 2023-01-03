using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Session
{
    public class Account
    {
        private string _name;
        private int _PIN;
        private bool _isAdmin;

        public Account(string name, int pin, bool isAdmin)
        {
            _name = name;
            _PIN = pin;
            _isAdmin = isAdmin;
        }
    }
}
