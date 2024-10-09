using System.Collections;
using Enemies;
using Global;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

namespace Player.Hands
{
    public class Hand : MonoBehaviour
    {  
        [SerializeField] private HandManager handManager; 
        [SerializeField] private WeaponData _weaponData;
        [SerializeField] private PlayerStats playerStats;

        #region Privates
        private Weapon _weapon; 
        private GameObject _currentWeaponGameObject;  
        
        private bool onDuration = false;
        private Enemy closestEnemy;

        #endregion
         
        private void Start()
        {
            handManager = transform.parent.GetComponent<HandManager>();
            playerStats = GameManager.Instance.playerManager.GetPlayer().GetComponent<PlayerStats>();
            ChangeWeapon(_weaponData);
        }

        private void Update()
        {
            CheckClosestEnemy();
            LookAt();
            UseHand();
        }
        public void SetupHand(WeaponData weaponData)
        {   
            _weaponData = weaponData; 
            _weapon = _weaponData.WeaponPrefab.GetComponent<Weapon>();  
        }
 
        public void UseHand()
        {
            if (!_weapon) return;
            if (onDuration) return;
            StartCoroutine(UseHandCoroutine());
        }

        private IEnumerator UseHandCoroutine()
        {
            onDuration = true;
            if (closestEnemy)
            {
                _weapon.Attack(closestEnemy);
                var attackTime = _weapon.weaponData.CurrentAttackTime; //this is as a seconds 
                var newAttackTime = (attackTime - (attackTime * playerStats.attackSpeed / 100)); //this is as removed percentage of attack time
                yield return new WaitForSeconds(newAttackTime);
            }
            onDuration = false;
        }

        public void ChangeWeapon(WeaponData weaponData)
        {
            if (_weapon != null)
            {
                _weapon.AttackStartedEvent -= OnAttackStarted;
                _weapon.AttackEndedEvent -= OnAttackEnded;
            }

            var weapon = Instantiate(weaponData.WeaponPrefab, transform);
            weapon.transform.parent = transform;

            if (_currentWeaponGameObject)
            {
                Destroy(_currentWeaponGameObject);
            }
            _currentWeaponGameObject = weapon;
            _weapon = weapon.GetComponent<Weapon>();

            if (_weapon != null)
            {
                _weapon.AttackStartedEvent += OnAttackStarted;
                _weapon.AttackEndedEvent += OnAttackEnded;

            }
        }

        private void OnAttackEnded()
        {
            // Handle the attack ended event 
        }

        private void OnAttackStarted()
        {
            // Handle the attack started event 
        }

        private void LookAt()
        {
            if (!closestEnemy) return;

            Vector2 direction = closestEnemy.transform.position - _currentWeaponGameObject.transform.position;

            var angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

            _currentWeaponGameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void CheckClosestEnemy()
        {
             closestEnemy = handManager.GetPlayerAttackZone().GetClosestEnemy();
        }
    }
}