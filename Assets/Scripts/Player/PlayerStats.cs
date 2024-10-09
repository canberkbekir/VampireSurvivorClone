using System;
using UnityEngine;
using Upgrades;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Player Stats")]
        public float health = 100f;
        public float damage = 10f;
        public float speed = 5f;
        public float attackSpeed = 1f;
        public float collectRange = 2f;
        public float attackRange = 1f;
        public float experienceMultiplier = 1.1f;

        // Base values to hold initial stats
        private float baseHealth;
        private float baseDamage;
        private float baseSpeed;
        private float baseAttackSpeed;
        private float baseCollectRange;
        private float baseAttackRange;
        private float baseExperienceMultiplier;

        #region Events
        public event Action OnHealthChanged;
        public event Action OnDamageChanged;
        public event Action OnSpeedChanged;
        public event Action OnAttackSpeedChanged;
        public event Action OnCollectRangeChanged;
        public event Action OnAttackRangeChanged;
        public event Action OnExperienceMultiplierChanged;
        #endregion

        private void Start()
        { 
            baseHealth = health;
            baseDamage = damage;
            baseSpeed = speed;
            baseAttackSpeed = attackSpeed;
            baseCollectRange = collectRange;
            baseAttackRange = attackRange;
            baseExperienceMultiplier = experienceMultiplier;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, collectRange);
        }

        public void SetUpgrade(UpgradeData upgrade)
        {
            switch (upgrade.StatType)
            {
                case StatType.Health:
                    health += baseHealth * (upgrade.StatValue / 100);
                    OnHealthChanged?.Invoke();
                    break;
                case StatType.Damage:
                    damage += baseDamage * (upgrade.StatValue / 100);
                    OnDamageChanged?.Invoke();
                    break;
                case StatType.AttackSpeed:
                    attackSpeed += baseAttackSpeed * (upgrade.StatValue / 100);
                    OnAttackSpeedChanged?.Invoke();
                    break;
                case StatType.Range:
                    attackRange += baseAttackRange * (upgrade.StatValue / 100);
                    OnAttackRangeChanged?.Invoke();
                    break;
                case StatType.Speed:
                    speed += baseSpeed * (upgrade.StatValue / 100);
                    OnSpeedChanged?.Invoke();
                    break;
                case StatType.CollectRange:
                    collectRange += baseCollectRange * (upgrade.StatValue / 100);
                    OnCollectRangeChanged?.Invoke();
                    break;
                case StatType.ExperienceMultiplier:
                    experienceMultiplier += baseExperienceMultiplier * (upgrade.StatValue / 100);
                    OnExperienceMultiplierChanged?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
