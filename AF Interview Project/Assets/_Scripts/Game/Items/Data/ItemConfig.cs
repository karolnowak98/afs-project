using System;
using UnityEngine;

namespace AFSInterview.Game.Items.Data
{
    //If I would have OdinInspector then I would use [InlineEditor] here
    [Serializable]
    public struct ItemConfig
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ItemData _itemData;
        
        public GameObject Prefab => _prefab;
        public ItemData ItemData => _itemData;
    }
}