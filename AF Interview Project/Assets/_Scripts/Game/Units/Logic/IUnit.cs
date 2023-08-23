using AFSInterview.Game.Units.Data;

namespace AFSInterview.Game.Units.Logic
{
    public interface IUnit
    {
        UnitConfig UnitConfig { get; }
        int InstanceId { get; }
        public bool CanAttack { get; }
        
        bool TryToKill(int damage);
        int CalculateDamage(IUnit target);
        void SkipTurn();
        void Destroy();
    }
}