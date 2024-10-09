using System;
using Enemies;
using Global;
using Player;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] public WeaponData weaponData;  
        [SerializeField] protected PlayerStats _playerStats;
        [SerializeField] protected Transform _handTransform; 
        [SerializeField] protected ParticleSystem _attackEffect;

        public abstract event Action AttackStartedEvent;
        public abstract event Action AttackEndedEvent;
       

        private void Start()
        { 
            _playerStats = GameManager.Instance.playerManager.GetPlayer().GetComponent<PlayerStats>();
            _handTransform = transform.parent.transform;
        } 
        
        public abstract void Attack(Enemy enemy);
        
       
    }
}
