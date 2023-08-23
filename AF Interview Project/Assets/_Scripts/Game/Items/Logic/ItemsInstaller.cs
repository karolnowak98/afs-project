using UnityEngine;
using Zenject;
using AFSInterview.Game.Items.Data;

namespace AFSInterview.Game.Items.Logic
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