using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        
        [Header("References")]
        [SerializeField] private PlayerStats playerStats;  

        [Header("Debug")] [SerializeField] private float _currentHealth; 

        public event Action OnPlayerDeath;
        private void Awake()
        {
            playerStats = gameObject.GetComponent<PlayerStats>();
            
            _currentHealth = playerStats.health;
        }

        public void Damage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Debug.Log("Player died");
                OnPlayerDeath?.Invoke();
            }
        }

        public void Heal(float heal)
        {
            _currentHealth += heal;
            if (_currentHealth > playerStats.health)
            {
                _currentHealth = playerStats.health;
            }
        }

        public float GetAttackRange()
        {
            return playerStats.attackRange;
        }
        
        public void SetAttackRange(float newAttackRange)
        {
            playerStats.attackRange = newAttackRange;
        }
    }
}