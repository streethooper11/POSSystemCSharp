using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MyPoSSystem.WholeBackend;
using MyPoSSystem.WholeBackend.Abstracts;
using MyPoSSystem.WholeBackend.DataStruct;

namespace MyPoSSystem.Sale
{
    public class Order
    {
        private MyObservableCollection<Item> _orderedItems;

        public Order()
        {
            _orderedItems = new MyObservableCollection<Item>();
        }

        public Order(MyObservableCollection<Item> orderedItems)
        {
            _orderedItems = orderedItems;
        }

        public void Add(Item item)
        {
            _orderedItems.Add(item);
        }

        public void RemoveMain(int index)
        {
            _orderedItems.RemoveAt(index);

            while ((index < _orderedItems.Count) && (_orderedItems[index] is Item_Option))
            {
                _orderedItems.RemoveAt(index);
            }
        }

        public void RemoveOption(int index)
        {
            _orderedItems.RemoveAt(index);
        }

        // split each item equally
        public List<Order> SplitBill(int nums)
        {
            var result = new List<Order>();

            return result;
        }

        // split based on the list of items
        public List<Order> SplitBill(List<MyObservableCollection<Item>> list)
        {
            var result = new List<Order>();

            return result;
        }
    }
}
