using System;
using System.Collections.Generic;
using AFSInterview.Units.Enums;
using UnityEngine;

namespace AFSInterview.Units.Data
{
    [Serializable]
    public class UnitConfig
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private UnitName name;
        [SerializeField] private List<UnitAttribute> attributes;
        [SerializeField] private int maxHealth;
        [SerializeField] private int armor;
        [SerializeField] private int attackDamage;
        [SerializeField] private int attackInterval;
        [SerializeField] private Dictionary<UnitAttribute, int> attributeOverrides;

        public GameObject Prefab => prefab;
        public UnitName Name => name;
        public List<UnitAttribute> Attributes => attributes;
        public int MaxHealth => maxHealth;
        public int Armor => armor;
        public int AttackDamage => attackDamage;
        public int AttackInterval => attackInterval;
        public Dictionary<UnitAttribute, int> AttributeOverrides => attributeOverrides;
        
        public UnitConfig(UnitName name)
        {
            attributeOverrides = new Dictionary<UnitAttribute, int>();
            this.name = name;
        }
    }
}