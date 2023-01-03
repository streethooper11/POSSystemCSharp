using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Session
{
    public class SessionAccount
    {
        private string? _tempLoginName;
        private static Account? Account_session;

        public static void SetSessionAccount(Account account)
        {
            Account_session = account;
        }
    }
}
