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
                _orderedItems.RemoveAt(index); // remove all options that follow the main item
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

            for (int i = 0; i < nums; i++)
            {
                result.Add(new Order());
            }

            decimal totalPrice, eachPrice, eachPriceWithPenny;
            int penniesDifference;

            foreach (var item in _orderedItems)
            {
                totalPrice = item.Price * 100; // multiplied by 100 to make it a whole number
                eachPrice = Math.Floor(totalPrice / nums);
                penniesDifference = (int)(totalPrice - (eachPrice * nums)); // calculates the difference of flooring value in the number of pennies

                eachPrice /= 100; // revert to 2 decimal places
                eachPriceWithPenny = eachPrice + 0.01m;

                for (int i = 0; i < nums; i++)
                {
                    if (penniesDifference == 0)
                    {
                        if (item is Item_Main)
                        {
                            result[i].Add(new Item_Main(item.Name, eachPrice, item.itemTaxPercentage, item.category));
                        }
                        else
                        {
                            result[i].Add(new Item_Option(item.Name, eachPrice, item.itemTaxPercentage, item.category));
                        }
                    }
                    else
                    {
                        if (item is Item_Main)
                        {
                            result[i].Add(new Item_Main(item.Name, eachPriceWithPenny, item.itemTaxPercentage, item.category));
                        }
                        else
                        {
                            result[i].Add(new Item_Option(item.Name, eachPriceWithPenny, item.itemTaxPercentage, item.category));
                        }

                        penniesDifference--;
                    }
                }
            }

            return result;
        }

        // split based on the list of items
        public List<Order> SplitBill(List<MyObservableCollection<Item>> list)
        {
            var result = new List<Order>();

            foreach (var order in list)
            {
                result.Add(new Order(order));
            }

            return result;
        }
    }
}
