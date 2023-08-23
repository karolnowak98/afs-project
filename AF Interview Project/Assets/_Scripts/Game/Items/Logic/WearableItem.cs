using AFSInterview.Game.Items.Data;
using AFSInterview.Game.Items.Logic.Interfaces;

namespace AFSInterview.Game.Items.Logic
{
    public class WearableItem : Item, IWearable
    {
        public WearableItem(ItemConfig itemConfig) : base(itemConfig) { }

        public void TakeOff()
        {
        }

        public void Wear()
        {
        }
    }
}