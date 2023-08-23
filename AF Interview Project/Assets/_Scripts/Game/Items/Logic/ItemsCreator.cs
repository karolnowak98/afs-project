using AFSInterview.Game.Items.Data;
using AFSInterview.Game.Items.Enums;
using AFSInterview.Game.Items.Logic.Interfaces;

namespace AFSInterview.Game.Items.Logic
{
    public class ItemsCreator
    {
        private readonly ItemsConfigs _itemsConfigs;
        
        public ItemsCreator(ItemsConfigs itemsConfigs)
        {
            _itemsConfigs = itemsConfigs;
        }
        
        public static IItem CreateItem(ItemConfig itemConfig)
        {
            IItem item = itemConfig.ItemData.ItemActionType switch
            {
                ItemActionType.None => new Item(itemConfig),
                ItemActionType.Usable => new ConsumableItem(itemConfig),
                ItemActionType.Wearable => new WearableItem(itemConfig),
                _ => new Item(itemConfig)
            };

            return item;
        }
        
        public IItem CreateItem(ItemName itemName)
        {
            var config = _itemsConfigs.GetConfigByName(itemName);
            
            IItem item = config.ItemData.ItemActionType switch
            {
                ItemActionType.None => new Item(config),
                ItemActionType.Usable => new ConsumableItem(config),
                ItemActionType.Wearable => new WearableItem(config),
                _ => new Item(config)
            };

            return item;
        }
    }
}