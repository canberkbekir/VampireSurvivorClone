using System;
using UnityEngine;

namespace Enemies.Behaviors
{
    public enum EnemyState { Idle, Chase, Attack }

    public class ChaserEnemyBehavior : EnemyBehavior
    {
        [Header("Debug")]
        [SerializeField] private EnemyState _currentState = EnemyState.Idle;


        private void LateUpdate()
        {
            UpdateEnemyState();
            HandleCurrentState();
        }

        private void HandleCurrentState()
        {
            switch (_currentState)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Chase:
                    Chase();
                    break;
                case EnemyState.Attack:
                    Attack();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_currentState), _currentState, null);
            }
        }
        private void UpdateEnemyState()
        {  
            if ((playerDistance - _enemyData.attackRange) <= _enemyData.attackRange)
            {
                SetState(EnemyState.Attack);
            }
            else if (playerDistance > _enemyData.attackRange && playerDistance <= _enemyData.chaseRange)
            {
                SetState(EnemyState.Chase);
            }
            else
            {
                SetState(EnemyState.Idle);
            }
        }
        
        private void SetState(EnemyState state)
        {
            _currentState = state; 
        }

        
        private void Idle()
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _enemyData.attackRange);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _enemyData.chaseRange);
        }
    }
    
  
}
