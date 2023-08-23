using System;
using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Game.Units.Enums;

namespace AFSInterview.Game.Units.Data
{
    [Serializable]
    public class UnitConfig
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private UnitName _name;
        [SerializeField] private List<UnitAttribute> _attributes = new();
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _armor;
        [SerializeField] private int _attackDamage;
        [SerializeField] private int _attackInterval;
        
        [SerializeField, Tooltip("The order is consistent with the names of the attributes above!")] 
        private List<int> _attributesBonusDamage = new();

        public GameObject Prefab => _prefab;
        public UnitName Name => _name;
        public List<UnitAttribute> Attributes => _attributes;
        public int MaxHealth => _maxHealth;
        public int Armor => _armor;
        public int AttackDamage => _attackDamage;
        public int AttackInterval => _attackInterval;
        public List<int> AttributesBonusDamage => _attributesBonusDamage;
        
        public UnitConfig(UnitName name)
        {
            _name = name;
       
            for (var i = 0; i < Enum.GetValues(typeof(UnitAttribute)).Length - 1; i++)
            {
                _attributesBonusDamage[i] = 0;
            }
        }
    }
}