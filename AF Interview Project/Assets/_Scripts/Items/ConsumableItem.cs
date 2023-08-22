using System;
using UnityEngine;

namespace AFSInterview.Items
{
    public class ConsumableItem : Item, IConsumable
    {
        public ConsumableItem(string name, int value) : base(name, value)
        {
            
        }

        public void Use(Action onUse)
        {
            Debug.Log("Using" + Name);
            onUse?.Invoke();
        }
    }
}