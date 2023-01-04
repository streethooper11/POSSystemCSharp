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

        public const string AllItemMainPath = "DB\\AllItemMain.json";
        public const string AllItemOptionPath = "DB\\AllItemOption.json";
        public const string AllMenuOptionPath = "DB\\AllMenuOption.json";

        public const string AssignedItemMainPath = "DB\\AssignedItemMain.json";
        public const string AssignedItemOptionPath = "DB\\AssignedItemOption.json";
        public const string AssignedMenuOptionPath = "DB\\AssignedMenuOption.json";
        public const string TopGroupPath = "DB\\TopGroup.json";

        public const string OrderPath = "DB\\Order.json";

        public const string SettingsPath = "DB\\Settings.json";

        public const string BackupExt = ".bak";
    }
}
