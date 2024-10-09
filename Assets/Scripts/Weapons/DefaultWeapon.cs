using System;
using DG.Tweening;
using Enemies; 
using UnityEngine;

namespace Weapons
{
    public class DefaultWeapon : Weapon
    {    
        public override event Action AttackStartedEvent;
        public override event Action AttackEndedEvent;

        public override void Attack(Enemy enemy)
        {    
            if (!enemy) return; 
            AttackStartedEvent?.Invoke(); 
            transform.DOMove(enemy.transform.position,weaponData.CurrentAttackTime/2, false).SetEase(Ease.InOutBack).OnComplete(()=>
            {
                enemy.TakeDamage(weaponData.Damage + _playerStats.damage);
                _attackEffect.Play();
                transform.DOLocalMove(Vector3.zero, weaponData.CurrentAttackTime / 2, false)
                    .OnUpdate(() =>
                    {
                        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10f); // Adjust rotation speed as needed
                    })
                    .OnComplete(() =>
                    {
                        transform.rotation = Quaternion.identity; 
                    });
            }); 
            AttackEndedEvent?.Invoke();
        }
    }
}
