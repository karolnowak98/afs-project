using System;
using System.Collections.Generic;

namespace AFSInterview.Items
{
    public class InventoryController
    {
        private readonly List<Item> _items = new ();
        private int _money;

        public int ItemsCount => _items.Count;

        private int Money
        {
            get => _money;
            set
            {
                if (value != _money)
                {
                    _money = value;
                    OnMoneyChanged?.Invoke(_money);
                }
            }
        }

        public event Action<int> OnMoneyChanged;
		
        public void SellAllItemsUpToValue(int maxValue)
        {
            var tempMoney = Money;
			
            for (var i = _items.Count - 1; i >= 0; i--)
            {
                var itemValue = _items[i].ItemData.MoneyValue;
                if (itemValue > maxValue) 
                    continue;
                tempMoney += itemValue;
                _items.RemoveAt(i);
            }

            Money = tempMoney;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}