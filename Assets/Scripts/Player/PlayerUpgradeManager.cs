using System;
using Player.Hands;
using UnityEngine;
using UnityEngine.Serialization;
using Upgrades;

namespace Player
{
    public class PlayerUpgradeManager : MonoBehaviour
    {
       [SerializeField] private HandManager handManager;
       [SerializeField] private PlayerStats playerStats;

       public void AssignUpgrade(UpgradeData upgrade)
       {
           switch (upgrade.Type)
           {
               case UpgradeType.WeaponUpgrade:
                     AssignWeaponUpgrade(upgrade);
                   break;
               case UpgradeType.StatUpgrade:
                   AssignStatUpgrade(upgrade);
                   break;
               case UpgradeType.EnvironmentUpgrade:
                   break;
               default:
                   throw new ArgumentOutOfRangeException();
           }
       }
       
         private void AssignWeaponUpgrade(UpgradeData upgrade)
         {
             handManager.AddHand(upgrade.WeaponData);
         }
       
         private void AssignStatUpgrade(UpgradeData upgrade)
         {
             playerStats.SetUpgrade(upgrade);
         }
       
       
         
    }
}
