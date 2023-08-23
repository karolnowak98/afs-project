using System;
using UnityEngine;

namespace AFSInterview.Game.Items.Data
{
    [Serializable]
    public struct ItemConfig
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ItemData _itemData;
        
        public GameObject Prefab => _prefab;
        public ItemData ItemData => _itemData;
    }
}