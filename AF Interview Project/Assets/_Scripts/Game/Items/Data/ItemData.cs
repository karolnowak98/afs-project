using System;
using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Game.Items.Enums;

namespace AFSInterview.Game.Items.Data
{
    [Serializable]
    public struct ItemData
    {
        [SerializeField] private ItemName _name;
        [SerializeField] private int _moneyValue;
        [SerializeField] private ItemActionType _itemActionType;
        [SerializeField] private List<ItemName> _itemsToGet;
        [SerializeField] private int _moneyToGet;
        
        public ItemName Name => _name;
        public int MoneyValue => _moneyValue;
        public ItemActionType ItemActionType => _itemActionType;
        public List<ItemName> ItemsToGet => _itemsToGet;
        public int MoneyToGet => _moneyToGet;
    }
}