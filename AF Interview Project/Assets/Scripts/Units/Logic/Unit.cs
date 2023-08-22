using AFSInterview.Units.Data;
using UnityEngine;

namespace AFSInterview.Units.Logic
{
    public class Unit
    {
        public UnitConfig UnitConfig { get; private set; }
        public Transform Transform { get; }
        public int Health { get; private set; }
        
        public void Destroy() => Object.Destroy(Transform.gameObject);

        public Unit(UnitConfig unitData, Transform transform)
        {
            UnitConfig = unitData;
            Transform = transform;
        }
        
        public int CalculateDamage(Unit target)
        {
            var damage = UnitConfig.AttackDamage;

            foreach (var attribute in target.UnitConfig.Attributes)
            {
                if (UnitConfig.AttributeOverrides.TryGetValue(attribute, out var value))
                {
                    damage += value;
                }
            }

            damage -= target.UnitConfig.Armor;
            return Mathf.Max(damage, 1);
        }
        
        public void Tick()
        {
            //Shot, rotate etc.
        }
    }
}