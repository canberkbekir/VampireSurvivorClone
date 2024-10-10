using System;
using UnityEngine;

namespace Enemies.Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData projectileData;  
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<Player.Player>().Damage(projectileData.damage);
            Destroy(gameObject);
        }
    }
}
