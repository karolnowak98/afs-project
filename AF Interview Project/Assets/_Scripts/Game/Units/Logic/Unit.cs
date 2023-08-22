using UnityEngine;
using AFSInterview.Game.Units.Data;

namespace AFSInterview.Game.Units.Logic
{
    public class Unit : IUnit
    {
        private readonly GameObject _gameObject;
        private int _currentAttackInterval = 1;
        private int _health;
        
        public UnitConfig UnitConfig { get; }
        public int InstanceId { get; }
        public bool CanAttack => UnitConfig.AttackInterval <= _currentAttackInterval;

        public Unit(UnitConfig unitData, GameObject gameObject)
        {
            UnitConfig = unitData;
            _gameObject = gameObject;
            _health = UnitConfig.MaxHealth;
            InstanceId = _gameObject.GetInstanceID();
        }

        public bool TakeDamage(int damage)
        {
            _health -= damage;
            
            return _health <= 0;
        }
        
        public int CalculateDamage(IUnit target)
        {
            var damage = UnitConfig.AttackDamage;
            
            _currentAttackInterval = 1;

            for (var index = 0; index < target.UnitConfig.Attributes.Count; index++)
            {
                var value = target.UnitConfig.AttributesBonusDamage[index];

                damage += value;
            }

            damage -= target.UnitConfig.Armor;
            
            return Mathf.Max(damage, 1);
        }

        public void SkipTurn() => _currentAttackInterval++;
        public void Destroy() => Object.Destroy(_gameObject);
    }
}