using UnityEngine;

namespace Weapons
{
    public enum WeaponType
    {
        Default,
        Pierce,
        Slash
    }
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackDefaultTime = 1f;
        [SerializeField] private float _attackSpeed;  
        [SerializeField] private WeaponType _weaponType; 
        [SerializeField] private float _range;
        [SerializeField] private GameObject _weaponPrefab;
        
        public float Damage => _damage;
        public float AttackSpeed => _attackSpeed;
        public WeaponType WeaponType => _weaponType;
        public float Range => _range;
        public GameObject WeaponPrefab => _weaponPrefab;
        public float CurrentAttackTime => _attackDefaultTime * (1 - (_attackSpeed / 100)); 
    } 
}