using AFSInterview.Game.Items.Data;
using UnityEngine;

namespace AFSInterview.Game.Items.Logic
{
    [RequireComponent(typeof(Collider))]
    public class ItemMono : MonoBehaviour
    {
        public ItemConfig ItemConfig { get; set; }
    }
}