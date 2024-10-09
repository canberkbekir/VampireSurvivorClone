using System; 
using System.Collections.Generic;
using DG.Tweening;
using Enemies;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapons
{
    public class BoomerangWeapon : Weapon
    {
        [SerializeField] private float boomerangThrowDistance = 3f; 
        [SerializeField] private float rotationsPerSecond = 2f;  

        private readonly HashSet<Enemy> _hitEnemies = new HashSet<Enemy>();  
        
        public override event Action AttackStartedEvent;
        public override event Action AttackEndedEvent;
        
        public override void Attack(Enemy enemy)
        {
            AttackStartedEvent?.Invoke();
            var direction = (enemy.transform.position - transform.position).normalized;
            var targetPosition = transform.position + (Vector3)direction * boomerangThrowDistance;  

            RotateBoomerang(weaponData.CurrentAttackTime);  
            transform.DOMove(targetPosition, weaponData.CurrentAttackTime / 2, false)
                .SetEase(Ease.OutSine)
                .OnComplete(() =>
                {
                    _hitEnemies.Clear(); 
                    transform.DOLocalMove(Vector3.zero, weaponData.CurrentAttackTime / 2, false)
                        .SetEase(Ease.InOutQuad)
                        .OnComplete(() =>
                        {
                            transform.rotation = Quaternion.identity;
                            AttackEndedEvent?.Invoke();
                            _hitEnemies.Clear(); // Reset hit enemies after boomerang returns
                        });
                });
        }

        private void RotateBoomerang(float duration)
        {
            var totalRotationAngle = 360f * rotationsPerSecond * duration;
            transform.DORotate(new Vector3(0f, 0f, totalRotationAngle), duration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear);
        } 
        private void OnTriggerEnter2D(Collider2D other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                TryDealDamage(enemy);
            }

        }

        private void TryDealDamage(Enemy enemy)
        {  
            if (_hitEnemies.Contains(enemy)) return;
            Debug.Log("Dealing damage to enemy: " + enemy.name);
            enemy.TakeDamage(weaponData.Damage + _playerStats.damage);  
            _attackEffect.Play();
            _hitEnemies.Add(enemy); 
        }
    }
}