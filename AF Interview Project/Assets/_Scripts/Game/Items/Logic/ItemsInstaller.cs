using AFSInterview.Game.Items.Data;
using UnityEngine;
using Zenject;

namespace AFSInterview.Items
{
    public class ItemsInstaller : MonoInstaller
    {
        [SerializeField] private InventoryConfig _inventoryConfig;
        [SerializeField] private ItemsConfigs _itemsConfigs;

        public override void InstallBindings()
        {
            Container.BindInstance(_inventoryConfig).AsSingle().NonLazy();
            Container.BindInstance(_itemsConfigs).AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<ItemsManager>().AsSingle();
        }
    }
}