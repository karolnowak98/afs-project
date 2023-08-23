using System;
using AFSInterview.Game.Items.Data;

namespace AFSInterview.Game.Items.Logic.Interfaces
{
    public interface IConsumable
    {
        void Use(Action<ItemConfig> onUse);
    }
}