﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend.Session
{
    public class SessionAccount
    {
        public Account? s_accountSession { get; private set; }

        public SessionAccount(Account account)
        {
            s_accountSession= account;
        }
    }
}
