using AFSInterview.Game.Items.Data;
using AFSInterview.Global.Logic;
using UnityEngine;

namespace AFSInterview.Items
{
    public class ItemsSpawner
    {
        private readonly ItemsConfigs _itemsConfigs;
        
        public ItemsSpawner(ItemsConfigs itemsConfigs)
        {
            _itemsConfigs = itemsConfigs;
        }
        
        public void SpawnNewItem()
        {
            var randomPosition = GetRandomSpawnPosition();
            var randomConfig = _itemsConfigs.GetRandomConfig;
            var obj = Object.Instantiate(randomConfig.Prefab, randomPosition, Quaternion.identity);
            obj.gameObject.TryGetComponent<ItemMono>(out var itemMono);
            itemMono.ItemData = randomConfig.ItemData;
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            var position = Vector3.zero;
            
            position.Random(-GetHalfDimensions(), GetHalfDimensions());
            position += _itemsConfigs.CenterOfSpawner;
            
            return position;
        }
        
        private Vector3 GetHalfDimensions()
        {
            var halfX = _itemsConfigs.SpawnerFieldDimensions.x * 0.5f;
            var halfZ = _itemsConfigs.SpawnerFieldDimensions.y * 0.5f;
            
            return new Vector3(halfX, 0f, halfZ);
        }
    }
}