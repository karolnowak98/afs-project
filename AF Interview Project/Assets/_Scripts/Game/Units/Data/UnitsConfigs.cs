using System;
using System.Linq;
using UnityEngine;
using AFSInterview.Game.Units.Enums;

namespace AFSInterview.Game.Units.Data
{
    [CreateAssetMenu(menuName = "Configs/Units Configs", fileName = "Units Configs")]
    public class UnitsConfigs : ScriptableObject
    {
        [SerializeField] private UnitConfig[] _configs = new UnitConfig[Enum.GetNames(typeof(UnitName)).Length];

        public UnitConfig GetConfigByName(UnitName unitName) => _configs.FirstOrDefault(unitConfig => unitName == unitConfig.Name);
    }
}