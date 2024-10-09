using Drops;
using UnityEngine;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public bool IsDead => _currentHealth <= 0;
        
        [Header("References")]
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private Drop _experinceDrop;
        
        [Header("Debug")]
        [SerializeField] private float _currentHealth;
        

        private void Awake()
        { 
            _currentHealth = _enemyData.health;
            _experinceDrop = GetComponent<Drop>();
        }

        public void TakeDamage(float damage)
         {
             if(_currentHealth <= 0) return; 
             
             _currentHealth -= damage;
             if (_currentHealth <= 0)
             { 
                 Die();
             }
         }
         
         private void Die()
         { 
             _experinceDrop.OnDrop();
             gameObject.SetActive(false);
         }
    }
}

