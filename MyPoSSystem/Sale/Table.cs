using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.WholeBackend.DataStruct;

namespace MyPoSSystem.Sale
{
    public class Table : INotifyPropertyChanged
    {
        private string _name;
        public MyObservableCollection<Order> Orders { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Table(string name)
        {
            _name = name;
            Orders = new MyObservableCollection<Order>();
        }

        public Table(string name, MyObservableCollection<Order> orders)
        {
            _name = name;
            Orders = orders;
        }

        public void SplitOrder(int index, int nums)
        {
            var result = Orders[index].Split(nums);

            Orders.RemoveAt(index);
            Orders.InsertRange(index, result);
            OnPropertyChanged();
        }

        public void SplitOrder(int index, List<MyObservableCollection<Item>> list)
        {
            var result = Orders[index].Split(list);

            Orders.RemoveAt(index);
            Orders.InsertRange(index, result);
            OnPropertyChanged();
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
