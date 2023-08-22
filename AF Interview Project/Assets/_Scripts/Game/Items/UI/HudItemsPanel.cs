using AFSInterview.Items;
using TMPro;
using UnityEngine;
using Zenject;

namespace AFSInterview.Game.Items.UI
{
    public class HudItemsPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyTMP;

        private ItemsManager _itemsManager;
        
        [Inject]
        private void Construct(ItemsManager itemsManager)
        {
            _itemsManager = itemsManager;

            _itemsManager.InventoryController.OnMoneyChanged += UpdateMoneyTMP;
        }

        private void OnDestroy()
        {
            _itemsManager.InventoryController.OnMoneyChanged -= UpdateMoneyTMP;
        }
        
        private void UpdateMoneyTMP(int moneyValue)
        {
            _moneyTMP.text = "Money: " + moneyValue;
        }
    }
}