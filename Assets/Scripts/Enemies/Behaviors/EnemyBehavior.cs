using System;
using System.Collections;
using Global;
using UnityEngine;

namespace Enemies.Behaviors
{
    public class EnemyBehavior : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected EnemyData _enemyData;
        [SerializeField] protected Player.Player player;
        [SerializeField] protected Rigidbody2D _rigidbody2D; 
        [SerializeField] protected float playerDistance;
        [SerializeField] protected bool isAttacking;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            player = GameManager.Instance.playerManager.GetPlayer();
        }
        private void Update()
        {
            UpdatePlayerDistance();
        }

        private void UpdatePlayerDistance()
        { 
            playerDistance = Vector3.Distance(transform.position, player.transform.position);
        }

        protected void Chase()
        {
            _rigidbody2D.velocity = (player.transform.position - transform.position).normalized * _enemyData.movementSpeed;  
        }
        
        protected void GoTo(Vector2 target)
        {
            _rigidbody2D.velocity = (target - (Vector2)transform.position).normalized * _enemyData.movementSpeed;
        }

        protected void Attack()
        {
            if (isAttacking) return;
            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            Debug.Log(gameObject.name + " is attacking the player");
            isAttacking = true;
            player.Damage(_enemyData.damage);
            yield return new WaitForSeconds(_enemyData.attackCooldown);
            isAttacking = false;
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _enemyData.attackRange); 
        }
    }
}