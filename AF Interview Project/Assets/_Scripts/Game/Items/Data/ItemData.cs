using System;
using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Game.Items.Enums;

namespace AFSInterview.Game.Items.Data
{
    //Consider changing ItemData to class and inherit
    [Serializable]
    public struct ItemData
    {
        [SerializeField] private ItemName _name;
        [SerializeField] private int _moneyValue;
        [SerializeField] private ItemActionType _itemActionType;
        
        //If I would have OdinInspector I would use ShowIf attribute to show/hide properties like itemsToGet, because they are related to use action type
        [SerializeField] private List<ItemName> _itemsToGet;
        [SerializeField] private int _moneyToGet;
        
        public ItemName Name => _name;
        public int MoneyValue => _moneyValue;
        public ItemActionType ItemActionType => _itemActionType;
        public List<ItemName> ItemsToGet => _itemsToGet;
        public int MoneyToGet => _moneyToGet;
    }
}