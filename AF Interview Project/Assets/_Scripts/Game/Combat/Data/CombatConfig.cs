using UnityEngine;

namespace AFSInterview.Game.Combat.Data
{
    [CreateAssetMenu(menuName = "Configs/Combat Config", fileName = "Combat Config")]
    public class CombatConfig : ScriptableObject
    {
        [SerializeField] private float _turnTime;
        [SerializeField] private ArmyConfig _xArmyConfig;
        [SerializeField] private ArmyConfig _oArmyConfig;

        public float TurnTime => _turnTime;
        public ArmyConfig XArmyConfig => _xArmyConfig;
        public ArmyConfig OArmyConfig => _oArmyConfig;
    }
}