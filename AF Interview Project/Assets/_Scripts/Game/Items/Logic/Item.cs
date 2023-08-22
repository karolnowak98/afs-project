using AFSInterview.Game.Items.Data;
using UnityEngine;

namespace AFSInterview.Items
{
    public class Item : IItem
    {
        private readonly GameObject _gameObject;
        
        public ItemData ItemData { get; }
        public int InstanceId { get; }

        public Item(ItemData itemData, GameObject gameObject)
        {
            ItemData = itemData;
            _gameObject = gameObject;
            InstanceId = _gameObject.GetInstanceID();
        }
        
        public void Destroy() => Object.Destroy(_gameObject);
    }
}