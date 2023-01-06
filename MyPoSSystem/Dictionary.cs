using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.WholeBackend
{
    public class ObservableDictionary<K, V> : Dictionary<K, V>, INotifyCollectionChanged
    {
        public ObservableDictionary() : base()
        {
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
