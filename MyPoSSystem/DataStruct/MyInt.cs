using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.DataStruct
{
    public class MyInt : INotifyPropertyChanged
    {
        private int _value;
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyInt(int value)
        {
            Value = value;
        }

        public static implicit operator int(MyInt obj) => obj.Value;
        public static implicit operator MyInt(int value) => new MyInt(value);

        public static MyInt operator ++(MyInt origin)
        {
            origin.Value++;
            return origin;
        }

        public static MyInt operator --(MyInt origin)
        {
            origin.Value--;
            return origin;
        }

        public static bool operator ==(MyInt obj1, MyInt obj2)
        {
            return obj1._value == obj2._value;
        }

        public static bool operator !=(MyInt obj1, MyInt obj2)
        {
            return obj1._value != obj2._value;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}