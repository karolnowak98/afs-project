using UnityEngine;

namespace AFSInterview.Game.Items.Data
{
    [CreateAssetMenu(menuName = "Configs/Inventory Config", fileName = "Inventory Config")]
    public class InventoryConfig : ScriptableObject
    {
        [SerializeField] private int _itemSellMaxValue;
        [SerializeField] private int _startingMoney;

        public int ItemSellMaxValue => _itemSellMaxValue;
        public int StartingMoney => _startingMoney;
    }
}