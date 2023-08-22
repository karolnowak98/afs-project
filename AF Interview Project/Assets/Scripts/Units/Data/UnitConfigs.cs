using System;
using System.Linq;
using AFSInterview.Units.Enums;
using UnityEngine;

namespace AFSInterview.Units.Data
{
    [CreateAssetMenu(menuName = "Configs/Units Config", fileName = "Units Config")]
    public class UnitConfigs : ScriptableObject
    {
        [SerializeField] private UnitConfig[] Configs = new UnitConfig[Enum.GetNames(typeof(UnitName)).Length];
        
        public UnitConfigs()
        {
            for (var i = 0; i < Enum.GetValues(typeof(UnitName)).Length; i++)
            {
                Configs[i] = new UnitConfig((UnitName)i);
            }
        }
        
        public UnitConfig GetConfigByName(UnitName unitName) => Configs.FirstOrDefault(unitConfig => unitName == unitConfig.Name);
    }
}