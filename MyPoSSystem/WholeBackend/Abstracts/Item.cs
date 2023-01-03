using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Source: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
    public abstract class Item : INotifyPropertyChanged
    {
        private string _name;
        private decimal _price;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected Item(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

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

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
