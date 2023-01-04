using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of an account with username and PIN
    public abstract class Account : INotifyPropertyChanged
    {
        private string _name;
        private string _password;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Account(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public bool PasswordMatch(string password)
        {
            if (_password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PasswordChange(string password)
        {
            _password = password;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
