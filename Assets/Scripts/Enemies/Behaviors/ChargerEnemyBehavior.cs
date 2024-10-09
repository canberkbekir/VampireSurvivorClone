using System.Collections;
using UnityEngine;

namespace Enemies.Behaviors
{
    public class ChargerEnemyBehavior : EnemyBehavior
    {
        [SerializeField] private bool isCharging = false;
        [SerializeField] private float chargeDistance = 5f;
        [SerializeField] private float chargeSpeed = 10f;
        [SerializeField] private float chargeWaitTime = 1f; // Time to wait before and after charging

        private bool isWaiting = false;

        private void FixedUpdate()
        {
            if (!isCharging && !isWaiting && IsPlayerInRange())
            {
                StartCoroutine(ChargeCoroutine());
            }
            else if (!isCharging && !isWaiting)
            {
                Chase(); 
            }
        }

        private IEnumerator ChargeCoroutine()
        {
            isWaiting = true;
            _rigidbody2D.velocity = Vector2.zero;
            
            // Wait for a second before starting the charge
            yield return new WaitForSeconds(chargeWaitTime);

            // Start charging
            isCharging = true;
            Vector2 chargeDirection = (player.transform.position - transform.position).normalized;
            float chargeDuration = chargeDistance / chargeSpeed;

            // Move the enemy towards the player for a certain duration
            _rigidbody2D.velocity = chargeDirection * chargeSpeed;

            // Wait for the duration of the charge
            yield return new WaitForSeconds(chargeDuration);

            // Stop the charge
            _rigidbody2D.velocity = Vector2.zero;
            isCharging = false;

            // Wait again after the charge
            yield return new WaitForSeconds(chargeWaitTime);

            isWaiting = false;
        }

        private bool IsPlayerInRange()
        {
            return playerDistance > 0 && playerDistance <= _enemyData.attackRange;
        }
 
    }
}