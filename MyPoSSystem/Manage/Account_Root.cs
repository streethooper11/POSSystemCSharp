using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Manage
{
    public class Account_Root : Account
    {
        public Account_Root(string name, string password) : base(name, password)
        {
        }
    }
}
