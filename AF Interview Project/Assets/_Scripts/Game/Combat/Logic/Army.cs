using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Game.Combat.Data;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Units.Data;
using AFSInterview.Game.Units.Enums;
using AFSInterview.Game.Units.Logic;
using AFSInterview.Global.Logic;

namespace AFSInterview.Game.Combat.Logic
{
    public class Army : IArmy
    {
        private readonly ArmyConfig _armyConfig;
        private readonly UnitsConfigs _unitsConfigs;
        
        public ArmySymbol ArmySymbol { get; }
        public List<IUnit> Units { get; } = new();
        public bool IsAnyoneAlive => Units.Count > 0;
        
        public Army(ArmyConfig armyConfig, UnitsConfigs unitsConfigs)
        {
            _armyConfig = armyConfig;
            _unitsConfigs = unitsConfigs;
            ArmySymbol = _armyConfig.ArmySymbol;
            InitUnits();
        }

        private void InitUnits()
        {
            for (var i = 0; i < _armyConfig.UnitNames.Count; i++)
            {
                for (var j = 0; j < _armyConfig.NumbersOfUnits[i]; j++)
                {
                    var config = _unitsConfigs.GetConfigByName((UnitName) i);
                    var newUnit = Object.Instantiate(config.Prefab, GetRandomSpawnPosition(), Quaternion.identity);
                    Units.Add(new Unit(config, newUnit));
                }
            }
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            var position = Vector3.zero;
            
            position.Random(-GetHalfDimensions(), GetHalfDimensions());
            position += _armyConfig.CenterOfSpawner;
            
            return position;
        }
        
        private Vector3 GetHalfDimensions()
        {
            var halfX = _armyConfig.SpawnerFieldDimensions.x * 0.5f;
            var halfZ = _armyConfig.SpawnerFieldDimensions.y * 0.5f;
            
            return new Vector3(halfX, 0f, halfZ);
        }
        
        public void RemoveUnit(IUnit unit)
        {
            Units.Remove(unit);
            unit.Destroy();
        }

        public void RemoveUnits()
        {
            foreach (var unit in Units.ToArray())
            {
                RemoveUnit(unit);
            }
        }
        
        public IUnit GetRandomUnit() => Units.PickRandom();
        public bool HasUnit(IUnit unit) => Units.Contains(unit);
    }
}