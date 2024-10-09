using System.Collections;
using UnityEngine;

namespace Enemies.Behaviors
{
    public class RangerEnemyBehavior : EnemyBehavior
    {
        #region Private variables
        private Vector2 _retreatPosition;
        private float _attackCooldownTimer;
        private bool _isAttackInCooldown => _attackCooldownTimer > 0;
        #endregion

        #region Unity Methods
        private void Start()
        {
            _attackCooldownTimer = 0f; // Initialize cooldown timer
        }

        private void FixedUpdate()
        {
            HandleAttackCooldown();

            if (IsPlayerInRange())
            {
                Debug.Log("Player is in range");
                RetreatFromPlayer();
                TryAttack();
            }
            else
            {
                ApproachPlayer();
            }
        }
        #endregion

        #region Private Methods
        // Handle the attack cooldown timer
        private void HandleAttackCooldown()
        {
            if (_isAttackInCooldown)
            {
                _attackCooldownTimer -= Time.fixedDeltaTime; // Decrease cooldown timer
            }
        }

        // Move towards the player
        private void ApproachPlayer()
        {
            GoTo(player.transform.position);
        }

        // Move away from the player
        private void RetreatFromPlayer()
        {
            Vector2 oppositeDirection = GetOppositeDirectionFromPlayer();
            GoTo(oppositeDirection);
        }
 
        private Vector2 GetOppositeDirectionFromPlayer()
        {
            return (transform.position - player.transform.position).normalized;
        }
 
        private bool IsPlayerInRange()
        {
            return playerDistance > 0 && playerDistance <= _enemyData.attackRange;
        }

        // Try to initiate the attack if cooldown allows
        private void TryAttack()
        {
            if (!_isAttackInCooldown)
            {
                _rigidbody2D.velocity = Vector2.zero; 
                StartCoroutine(PerformAttack());
            }
        }
 
        private IEnumerator PerformAttack()
        {
            if (_isAttackInCooldown) yield break; // Exit if still in cooldown

            _attackCooldownTimer = _enemyData.attackCooldown; // Reset the cooldown

            FireProjectile();

            yield return new WaitForSeconds(_enemyData.attackCooldown); // Wait for cooldown to finish
        }
 
        private void FireProjectile()
        {
            var projectile = Instantiate(_enemyData.projectilePrefab, transform.position, Quaternion.identity);
            var projectileRb = projectile.GetComponent<Rigidbody2D>();
            Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;

            projectileRb.velocity = directionToPlayer * _enemyData.projectileSpeed;
        }
        #endregion
    }
}
