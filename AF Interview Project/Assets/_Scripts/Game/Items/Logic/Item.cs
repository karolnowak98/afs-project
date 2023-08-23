using System;
using AFSInterview.Game.Items.Data;
using AFSInterview.Game.Items.Logic.Interfaces;

namespace AFSInterview.Game.Items.Logic
{
    public class Item : IItem
    {
        public ItemConfig ItemConfig { get; }
        public string UniqueId { get; }

        public Item(ItemConfig itemConfig)
        {
            ItemConfig = itemConfig;
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}