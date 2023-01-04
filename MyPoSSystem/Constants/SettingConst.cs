using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Constants
{
    public class SettingConst
    {
        private const string key1 = "us";
        private const string key2 = "goukene";
        private const string key3 = "f4gen5fst.mkh";
        private const string key4 = "xtatsu5f";
        private const string key5 = "pstreet11";

        public const string Currency = "currency";
        public const string Language = "language";
        public const string Printer = "printer";
        public const string Tax = "tax";

        public static string CreateKey()
        {
            return key1 + key3 + key5 + key2 + key4;
        }
    }
}
