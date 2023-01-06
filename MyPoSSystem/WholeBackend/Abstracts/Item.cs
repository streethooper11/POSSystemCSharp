using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Xml.Linq;

namespace MyPoSSystem.WholeBackend.Abstracts
{
    // Abstract representation of an item with name and price
    // Source for INotifyPropertyChanged:
    // https://learn.microsoft.com/en-us/dotnet/desktop/wpf/data/how-to-implement-property-change-notification?view=netframeworkdesktop-4.8
    public abstract class Item : INotifyPropertyChanged
    {
        private string _name;
        private decimal _price;
        public decimal itemTaxPercentage { get; protected set; }
        public string category;

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

        protected Item(string name, decimal price, string category)
        {
            _name = name;
            _price = price;
            this.category = category;
        }

        protected Item(string name, decimal price, decimal itemTaxPercentage, string category) : this(name, price, category)
        {
            this.itemTaxPercentage = itemTaxPercentage;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
