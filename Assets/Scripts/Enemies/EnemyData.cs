using UnityEngine;

namespace Enemies
{
    public enum EnemyType { Default, Ranged }
    
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public float movementSpeed;
        public float health;
        public float damage;
        public float attackRange;
        public float chaseRange;
        public float attackCooldown;  
        public float projectileSpeed;
        public int experienceMultiplier;
        public GameObject projectilePrefab;
        public GameObject enemyPrefab;
        public EnemyType enemyType;
    }
}
