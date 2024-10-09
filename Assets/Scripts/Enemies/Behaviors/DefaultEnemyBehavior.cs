using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies.Behaviors
{
    public class DefaultEnemyBehavior : EnemyBehavior
    {
        private void FixedUpdate()
        {
            Chase(); 
        }

        private void LateUpdate()
        {
            CheckIsPlayerInRange(); 
        }
        
        private void CheckIsPlayerInRange()
        {
            if (playerDistance == 0) return;
            
            if ((playerDistance - _enemyData.attackRange) <= _enemyData.attackRange)
            {  
                Attack();
            }

        }
    }
}
