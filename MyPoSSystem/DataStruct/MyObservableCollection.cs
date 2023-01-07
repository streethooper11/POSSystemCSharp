using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyPoSSystem.DataStruct
{
    // https://stackoverflow.com/questions/901921/observablecollection-and-item-propertychanged
    public class MyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public MyObservableCollection()
        {
            CollectionChanged += items_CollectionChanged;
        }


        public MyObservableCollection(IEnumerable<T> collection) : base(collection)
        {
            CollectionChanged += items_CollectionChanged;
            foreach (INotifyPropertyChanged item in collection)
            {
                if (item != null)
                {
                    item.PropertyChanged += item_PropertyChanged;
                }
            }
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            CheckReentrancy();

            foreach (var item in collection)
            {
                InsertItem(index, item);
                index++;
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            CheckReentrancy();

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        private void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.OldItems != null)
                    foreach (INotifyPropertyChanged item in e.OldItems)
                    {
                        if (item != null)
                        {
                            item.PropertyChanged -= item_PropertyChanged;
                        }
                    }

                if (e.NewItems != null)
                    foreach (INotifyPropertyChanged item in e.NewItems)
                        if (item != null)
                        {
                            item.PropertyChanged += item_PropertyChanged;
                        }
            }
        }

        private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var reset = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            OnCollectionChanged(reset);
        }
    }
}