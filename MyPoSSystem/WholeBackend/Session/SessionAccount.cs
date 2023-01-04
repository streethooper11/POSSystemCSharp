using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;

namespace MyPoSSystem.WholeBackend.Session
{
    public class SessionAccount
    {
        private string? _tempLoginName;
        private static Account? s_accountSession;

        public static void SetSessionAccount(Account account)
        {
            s_accountSession = account;
        }
    }
}
