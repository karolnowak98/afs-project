using System;

namespace AFSInterview.Items
{
    public interface IConsumable
    {
        void Use(Action onUse);
    }
}