using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using AFSInterview.Game.Combat.Data;
using AFSInterview.Game.Combat.Enums;
using AFSInterview.Game.Units.Data;
using AFSInterview.Game.Units.Enums;
using AFSInterview.Game.Units.Logic;
using AFSInterview.Global.Logic;

namespace AFSInterview.Game.Combat.Logic
{
    public class CombatManager : IInitializable, ITickable
    {
        private readonly List<IUnit> _turns = new();
        private CombatConfig _combatConfig;
        private UnitsConfigs _unitsConfigs;
        private IArmy _xArmy;
        private IArmy _oArmy;
        private float _nextTurnTime;
        private bool _combatEnded;

        public event Action<ArmySymbol> OnCombatEnd;
        public event Action<UnitName, ArmySymbol> OnMakeTurn;
        
        [Inject]
        private void Construct(CombatConfig combatConfig, UnitsConfigs unitsConfigs)
        {
            _combatConfig = combatConfig;
            _unitsConfigs = unitsConfigs;
        }

        public void Initialize()
        {
            _xArmy = new Army(_combatConfig.XArmyConfig, _unitsConfigs);
            _oArmy = new Army(_combatConfig.OArmyConfig, _unitsConfigs);
            _nextTurnTime = _combatConfig.TurnTime;
            _combatEnded = false;
            
            _turns.AddRange(_xArmy.Units);
            _turns.AddRange(_oArmy.Units);
            _turns.Shuffle();
        }

        public void Tick()
        {
            if (_combatEnded) return;
            if (Time.time < _nextTurnTime) return;
            
            _nextTurnTime = Time.time + _combatConfig.TurnTime;
            MakeTurn();
        }

        public void RestartCombat()
        {
            _turns.Clear();
            _xArmy.RemoveUnits();
            _oArmy.RemoveUnits();
            Initialize();
        }
        
        private void MakeTurn()
        {
            var currentUnit = _turns[0];
            
            DetermineArmies(currentUnit, out var currentArmy, out var enemyArmy);

            if (!currentUnit.CanAttack)
            {
                SkipTurn(currentUnit, currentArmy);
                return;
            }
            
            var enemyUnit = enemyArmy.GetRandomUnit();
            AttackUnit(currentUnit, currentArmy, enemyUnit, enemyArmy);
            
            _turns.Add(currentUnit);
            _turns.Remove(currentUnit);
            
            OnMakeTurn?.Invoke(currentUnit.UnitConfig.Name, currentArmy.ArmySymbol);
        }
        
        private void AttackUnit(IUnit unit, IArmy currentArmy, IUnit enemyUnit, IArmy enemyArmy)
        {
            var damage = unit.CalculateDamage(enemyUnit);

            if (enemyUnit.TakeDamage(damage))
            {
                enemyArmy.RemoveUnit(enemyUnit);
                _turns.Remove(enemyUnit);

                if (!enemyArmy.IsAnyoneAlive)
                {
                    _combatEnded = true;
                    OnCombatEnd?.Invoke(currentArmy.ArmySymbol);
                    Debug.Log("Army " + "(" + currentArmy.ArmySymbol + ") won!!");
                }
            }

            Debug.Log(unit.UnitConfig.Name + "( " + unit.InstanceId + ") attacked:  " + enemyUnit.UnitConfig.Name + "(" + enemyUnit.InstanceId + ")!!");
        }
        
        private void SkipTurn(IUnit unit, IArmy currentArmy)
        {
            unit.SkipTurn();
            _turns.Add(unit);
            _turns.Remove(unit);
            OnMakeTurn?.Invoke(unit.UnitConfig.Name, currentArmy.ArmySymbol);
            Debug.Log(unit.UnitConfig.Name + "( " + unit.InstanceId + ") skipped turn!!");
        }
        
        private void DetermineArmies(IUnit unit, out IArmy currentArmy, out IArmy enemyArmy)
        {
            if (_xArmy.HasUnit(unit))
            {
                currentArmy = _xArmy;
                enemyArmy = _oArmy;
            }
            else
            {
                currentArmy = _oArmy;
                enemyArmy = _xArmy;
            }
        }
    }
}