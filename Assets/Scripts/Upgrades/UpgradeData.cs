using UnityEngine;
using Weapons;

namespace Upgrades
{
    public enum UpgradeType
    {
        WeaponUpgrade,
        StatUpgrade,
        EnvironmentUpgrade
    }
    
    public enum StatType
    {
        Health,
        Damage,
        AttackSpeed,
        Range,
        Speed,
        AttackRange,
        CollectRange,
        ExperienceMultiplier 
    }

    [CreateAssetMenu(fileName = "UpgradeData", menuName = "Upgrade/UpgradeData")] 
    public class UpgradeData : ScriptableObject
    {
        [SerializeField] private UpgradeType type;  
        [SerializeField] private string title;
        [SerializeField] private string description;
        
        [Header("Weapon Upgrade")]
        [SerializeField] private WeaponData weaponData;

        [Header("Stat Upgrade")]
        [SerializeField] private StatType statType;
        [SerializeField] private float statValue;
        
        public UpgradeType Type => type;
        public string Title => title;
        public string Description => description;
        public WeaponData WeaponData => weaponData;
        
        public StatType StatType => statType;
        public float StatValue => statValue;
        
        
    }
}