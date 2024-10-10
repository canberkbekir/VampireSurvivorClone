using UnityEngine;

namespace Enemies.Projectiles
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Projectile/Projectile Data", order = 0)]
    public class ProjectileData : ScriptableObject
    {
        [Header("Projectile Data")]
        public float speed;
        public float damage;
       
    }
}
