using Enemies;
using Global;
using UnityEngine;

namespace Player
{
    public class PlayerAttackZone : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerStats _playerStats; 
        
        [Header("Debug")]
        [SerializeField] private int countEnemiesInRange;
        [SerializeField] private Enemy _closestEnemy;
        [SerializeField] private float _attackRange;

        private void Awake()
        {
            _gameManager = GameManager.Instance;
        }

        private void Start()
        {
            _playerStats = _gameManager.playerManager.GetPlayerStats(); 
            _playerStats.OnAttackRangeChanged += OnAttackRangeChanged;
        }

        private void OnAttackRangeChanged()
        {
            _attackRange = _playerStats.attackRange; 
        }

        private void Update()
        {
            CheckForEnemiesInRange();
        }

        private void CheckForEnemiesInRange()
        { 
            var colliders = Physics2D.OverlapCircleAll(transform.position, _attackRange); // Use cached value
            UpdateEnemiesInRange(colliders);
            _closestEnemy = GetClosestEnemy(colliders);
        }

        private void UpdateEnemiesInRange(Collider2D[] colliders)
        {
            countEnemiesInRange = 0;
            foreach (var col in colliders)
            {
                if (col.CompareTag("Enemy"))
                {
                    countEnemiesInRange++;
                }
            }
        }
        
        private Enemy GetClosestEnemy(Collider2D[] colliders)
        {
            Enemy closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (var col in colliders)
            {
                if (!col.CompareTag("Enemy")) continue;

                float distance = Vector2.Distance(transform.position, col.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance; 
                    closestEnemy = col.gameObject.GetComponent<Enemy>(); 
                }
            }
            
            return closestEnemy;
        }
        
        public Enemy GetClosestEnemy()
        {
            return _closestEnemy;
        }

        private void OnDrawGizmos()
        {
            if (_playerStats != null) // Check if player exists before drawing gizmos
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _playerStats.attackRange);
            }
        }
    }
}
