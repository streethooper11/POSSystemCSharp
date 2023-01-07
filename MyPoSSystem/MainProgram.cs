using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MyPoSSystem.Constants;
using MyPoSSystem.Backend;

namespace MyPoSSystem
{
    public class MainProgram
    {
        private Window _window;
        private SessionDB _sessionDB;
        private SessionAccount _sessionAccount;

        public MainProgram(Window window)
        {
            _window = window;
            _sessionDB = new SessionDBJson();
        }
    }
}
