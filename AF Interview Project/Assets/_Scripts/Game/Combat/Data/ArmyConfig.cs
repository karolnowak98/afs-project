﻿using System;
using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Units.Enums;

namespace AFSInterview.Game.Combat.Data
{
    [Serializable]
    public class ArmyConfig
    {
        [SerializeField] private List<int> _numbersOfUnits = new();
        [SerializeField] private List<UnitName> _unitNames = new();
        [SerializeField] private ArmySymbol _armySymbol;
        [SerializeField] private Vector3 _centerOfSpawner;
        [SerializeField] private Vector2 _spawnerFieldDimensions;

        public ArmySymbol ArmySymbol => _armySymbol;
        public List<int> NumbersOfUnits => _numbersOfUnits;
        public List<UnitName> UnitNames => _unitNames;
        public Vector3 CenterOfSpawner => _centerOfSpawner;
        public Vector2 SpawnerFieldDimensions => _spawnerFieldDimensions;
        
        public ArmyConfig()
        {
            for (var i = 0; i < Enum.GetValues(typeof(UnitName)).Length; i++)
            {
                _unitNames.Add((UnitName) i);
                _numbersOfUnits.Add(0);
            }
        }
    }
}