using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using MyPoSSystem.WholeBackend.Abstracts;
using MyPoSSystem.WholeBackend.DataStruct;

namespace MyPoSSystem.Sale
{
    public class Store : INotifyPropertyChanged
    {
        private MyObservableCollection<Table> _tables;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Store()
        {
            _tables = new MyObservableCollection<Table>();

        }

        public Store(MyObservableCollection<Table> tables)
        {
            _tables = tables;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
