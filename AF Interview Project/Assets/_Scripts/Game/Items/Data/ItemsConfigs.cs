using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AFSInterview.Game.Items.Enums;
using AFSInterview.Global.Logic;

namespace AFSInterview.Game.Items.Data
{
    [CreateAssetMenu(menuName = "Configs/Items Configs", fileName = "Items Configs")]
    public class ItemsConfigs : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> _configs = new();
        [SerializeField] private float _spawnInterval;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Vector3 _centerOfSpawner;
        [SerializeField] private Vector2 _spawnerFieldDimensions;

        public float SpawnInterval => _spawnInterval;
        public LayerMask LayerMask => _layerMask;
        public Vector3 CenterOfSpawner => _centerOfSpawner;
        public Vector2 SpawnerFieldDimensions => _spawnerFieldDimensions;
        public ItemConfig GetRandomConfig => _configs.PickRandom();
        
        public ItemConfig GetConfigByName(ItemName itemName) => _configs.FirstOrDefault(itemConfig => itemName == itemConfig.ItemData.Name);
    }
}