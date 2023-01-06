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
        public const string DBFolder = "DB";

        public const string AllItemMainPath = "DB\\AllItemMain.db";
        public const string AllItemOptionPath = "DB\\AllItemOption.db";
        public const string AllMenuMainPath = "DB\\AllMenuMain.db";
        public const string AllMenuOptionPath = "DB\\AllMenuOption.db";

        public const string AccountPath = "DB\\Accounts.db";

        public const string AssignedItemMainPath = "DB\\AssignedItemMain.db";
        public const string AssignedItemOptionPath = "DB\\AssignedItemOption.db";
        public const string AssignedMenuMainPath = "DB\\AssignedMenuMain.db";
        public const string AssignedMenuOptionPath = "DB\\AssignedMenuOption.db";

        public const string SettingsPath = "DB\\Settings.db";

        public const string OrderPath = "DB\\Orders.db";

        public const string BackupExt = ".bak";
    }
}
