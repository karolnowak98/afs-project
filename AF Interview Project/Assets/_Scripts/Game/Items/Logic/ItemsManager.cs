using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;
using Zenject;
using AFSInterview.Game.Items.Data;

namespace AFSInterview.Game.Items.Logic
{
    public class ItemsManager : IInitializable, ITickable
    {
        private ItemsConfigs _itemsConfigs;
        private InventoryConfig _inventoryConfig;
        private ItemsSpawner _itemsSpawner;
        private ItemsCreator _itemsCreator;
        private float _nextItemSpawnTime;
        private Camera _mainCam;
        
        public InventoryController InventoryController { get; private set; }

        [Inject]
        private void Construct(ItemsConfigs itemsConfigs, InventoryConfig inventoryConfig)
        {
            _itemsConfigs = itemsConfigs;
            _inventoryConfig = inventoryConfig;
            _mainCam = Camera.main;

            _itemsCreator = new ItemsCreator(_itemsConfigs);
            _itemsSpawner = new ItemsSpawner(_itemsConfigs);
            InventoryController = new InventoryController(_itemsCreator);
        }
        
        public void Initialize()
        {
            InventoryController.Money = _inventoryConfig.StartingMoney;
        }
        
        public void Tick()
        {
            if (Time.time >= _nextItemSpawnTime)
            {
                _nextItemSpawnTime = Time.time + _itemsConfigs.SpawnInterval;
                _itemsSpawner.SpawnNewItem();
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                TryPickUpItem();
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                InventoryController.SellAllItemsUpToValue(_inventoryConfig.ItemSellMaxValue);
            }
            
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                InventoryController.UseRandomConsumableItem();
            }
        }

        private void TryPickUpItem()
        {
            var ray = _mainCam.ScreenPointToRay(Input.mousePosition);
			
            if (!Physics.Raycast(ray, out var hit, 100f, _itemsConfigs.LayerMask)) return;
            if (!hit.collider.TryGetComponent<ItemMono>(out var itemMono)) return;

            var gameObject = hit.transform.gameObject;
            var item = ItemsCreator.CreateItem(itemMono.ItemConfig);

            InventoryController.AddItem(item);
            Object.Destroy(gameObject);

            var itemConfig = item.ItemConfig;
            
            Debug.Log($"Picked up {itemConfig.ItemData.Name} with value of {itemConfig.ItemData.MoneyValue} and now have {InventoryController.ItemsCount} items");
        }
    }
}