using AFSInterview.Game.Items.Data;
using UnityEngine;
using Zenject;

namespace AFSInterview.Items
{
    public class ItemsManager : ITickable
    {
        private ItemsConfigs _itemsConfigs;
        private InventoryConfig _inventoryConfig;
        private ItemsSpawner _itemsSpawner;
        private float _nextItemSpawnTime;
        private Camera _mainCam;
        
        public InventoryController InventoryController { get; private set; }

        [Inject]
        private void Construct(ItemsConfigs itemsConfigs, InventoryConfig inventoryConfig)
        {
            _itemsConfigs = itemsConfigs;
            _inventoryConfig = inventoryConfig;
            _mainCam = Camera.main;
            
            InventoryController = new InventoryController();
            _itemsSpawner = new ItemsSpawner(_itemsConfigs);
        }
        
        public void Tick()
        {
            if (Time.time >= _nextItemSpawnTime)
            {
                _nextItemSpawnTime = Time.time + _itemsConfigs.SpawnInterval;
                _itemsSpawner.SpawnNewItem();
            }

            if (Input.GetMouseButtonDown(0))
            {
                TryPickUpItem();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                InventoryController.SellAllItemsUpToValue(_inventoryConfig.ItemSellMaxValue);
            }
        }

        private void TryPickUpItem()
        {
            var ray = _mainCam.ScreenPointToRay(Input.mousePosition);
			
            if (!Physics.Raycast(ray, out var hit, 100f, _itemsConfigs.LayerMask)) return;
            if (!hit.collider.TryGetComponent<ItemMono>(out var itemMono)) return;

            var gameObject = hit.transform.gameObject;
            var item = new Item(itemMono.ItemData, gameObject);
            
            InventoryController.AddItem(item);
            Object.Destroy(gameObject);

            var itemData = item.ItemData;
            
            //If not needed, log could be deleted
            Debug.Log($"Picked up {itemData.Name} with value of {itemData.MoneyValue} and now have {InventoryController.ItemsCount} items");
        }
    }
}