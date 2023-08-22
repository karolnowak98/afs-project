using UnityEngine;

namespace AFSInterview.Game.Items.Data
{
    [CreateAssetMenu(menuName = "Configs/Inventory Config", fileName = "Inventory Config")]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private int _itemSellMaxValue;

        public int ItemSellMaxValue => _itemSellMaxValue;
    }
}