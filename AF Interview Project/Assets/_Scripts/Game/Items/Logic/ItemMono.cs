using AFSInterview.Game.Items.Data;
using UnityEngine;

namespace AFSInterview.Items
{
    [RequireComponent(typeof(Collider))]
    public class ItemMono : MonoBehaviour
    {
        public ItemData ItemData { get; set; }
    }
}