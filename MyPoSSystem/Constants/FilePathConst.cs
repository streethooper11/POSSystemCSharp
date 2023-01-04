using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.Constants
{
    public class FilePathConst
    {
        public const string AccountPath = "DB\\Account.json";

        public const string ItemMainPath = "DB\\ItemMain.json";
        public const string ItemOptionPath = "DB\\ItemOption.json";
        public const string MenuOptionPath = "DB\\MenuOption.json";
        public const string TopGroupPath = "DB\\TopGroup.json";

        public const string OrderPath = "DB\\Order.json";

        public const string SettingsPath = "DB\\Settings.json";

        public const string BackupExt = ".bak";
    }
}
