using AFSInterview.Game.Items.Data;

namespace AFSInterview.Game.Items.Logic.Interfaces
{
    public interface IItem
    {
        public ItemConfig ItemConfig { get; }
        public string UniqueId { get; }
    }
}