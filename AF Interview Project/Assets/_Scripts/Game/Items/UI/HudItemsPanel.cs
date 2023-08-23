using UnityEngine;
using Zenject;
using TMPro;
using AFSInterview.Game.Items.Logic;

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