using System;
using AFSInterview.Game.Items.Enums;
using UnityEngine;

namespace AFSInterview.Game.Items.Data
{
    [Serializable]
    public struct ItemData
    {
        [SerializeField] private ItemName _name;
        [SerializeField] private int _moneyValue;
        
        public ItemName Name => _name;
        public int MoneyValue => _moneyValue;
    }
}