using System;
using System.Linq;
using UnityEngine;
using AFSInterview.Game.Units.Enums;

namespace AFSInterview.Game.Units.Data
{
    [CreateAssetMenu(menuName = "Configs/Units Config", fileName = "Units Config")]
    public class UnitsConfigs : ScriptableObject
    {
        [SerializeField] private UnitConfig[] _configs = new UnitConfig[Enum.GetNames(typeof(UnitName)).Length];
        
        public UnitsConfigs()
        {
            for (var i = 0; i < Enum.GetValues(typeof(UnitName)).Length; i++)
            {
                _configs[i] = new UnitConfig((UnitName) i);
            }
        }
        
        public UnitConfig GetConfigByName(UnitName unitName) => _configs.FirstOrDefault(unitConfig => unitName == unitConfig.Name);
    }
}