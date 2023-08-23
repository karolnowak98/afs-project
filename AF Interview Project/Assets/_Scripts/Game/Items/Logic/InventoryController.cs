using System;
using System.Collections.Generic;
using UnityEngine;
using ModestTree;
using AFSInterview.Game.Items.Data;
using AFSInterview.Game.Items.Enums;
using AFSInterview.Game.Items.Logic.Interfaces;

namespace AFSInterview.Game.Items.Logic
{
    public class InventoryController
    {
        private readonly List<IItem> _items = new ();
        private readonly ItemsCreator _itemsCreator;
        
        private int _money;
        
        public int Money
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

        public InventoryController(ItemsCreator itemsCreator)
        {
            _itemsCreator = itemsCreator;
        }

        public int ItemsCount => _items.Count;
        
        public event Action<int> OnMoneyChanged;
		
        public void SellAllItemsUpToValue(int maxValue)
        {
            var tempMoney = Money;
			
            for (var i = _items.Count - 1; i >= 0; i--)
            {
                var itemValue = _items[i].ItemConfig.ItemData.MoneyValue;
                if (itemValue > maxValue) 
                    continue;
                tempMoney += itemValue;
                _items.RemoveAt(i);
            }

            Money = tempMoney;
            OnMoneyChanged?.Invoke(Money);
        }

        public void AddItem(IItem item)
        {
            _items.Add(item);
        }

        public void UseRandomConsumableItem()
        {
            foreach (var item in _items.ToArray())
            {
                if (item is not IConsumable consumable) continue;
                
                consumable.Use(UseConsumableItem);
                _items.Remove(item);
                return;
            }
        }

        private void UseConsumableItem(ItemConfig itemConfig)
        {
            if (itemConfig.ItemData.ItemActionType != ItemActionType.Usable) return;

            var itemsToGet = itemConfig.ItemData.ItemsToGet;
            var moneyToGet = itemConfig.ItemData.MoneyToGet;
                        
            if (!itemsToGet.IsEmpty())
            {
                foreach (var itemName in itemsToGet)
                {
                    _items.Add(_itemsCreator.CreateItem(itemName));
                    
                    Debug.Log($"You found an item: {itemName}!!");
                }
            }
            
            Money += moneyToGet;
            Debug.Log($"You found {moneyToGet} money!!");
        }
    }
}