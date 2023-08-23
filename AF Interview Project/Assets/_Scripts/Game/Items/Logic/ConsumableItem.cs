using System;
using AFSInterview.Game.Items.Data;
using AFSInterview.Game.Items.Logic.Interfaces;

namespace AFSInterview.Game.Items.Logic
{
    public class ConsumableItem : Item, IConsumable
    {
        public ConsumableItem(ItemConfig itemConfig) : base(itemConfig) { }

        public void Use(Action<ItemConfig> onUse)
        {
            onUse?.Invoke(ItemConfig);
        }
    }
}