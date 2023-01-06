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
        private const string key6 = "iwhekrjtd";
        private const string key7 = "rTAGcombo";
        private const string key8 = "AAAAAfo";

        public const string Currency = "currency";
        public const string Language = "language";
        public const string Printer = "printer";
        public const string Tax = "tax";

        public const decimal DefaultTax = 5.00m;

        public const int RootAccountButtonId = -1;
        public const int NoAssignedEntityId = -1;

        public const int MaxAccountButtonNo = 30;
        public const int MaxItemMainButtonNo = 18;
        public const int MaxItemOptionButtonNo = 24;
        public const int MaxMenuMainButtonNo = 12;
        public const int MaxMenuOptionButtonNo = 20;

        public static string CreateKey()
        {
            return key1 + key3 + key5 + key2 + key4 + key8 + key6 + key7;
        }
    }
}
