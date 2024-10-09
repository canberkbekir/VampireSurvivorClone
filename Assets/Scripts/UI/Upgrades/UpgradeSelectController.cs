using System;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace UI.Upgrades
{
    public class UpgradeSelectController : MonoBehaviour
    {
        [SerializeField] private GameObject upgradeCardObject;
        [SerializeField] private List<GameObject> upgradeCards;
        
        public event Action<UpgradeData> OnUpgradeSelected;
        
        public void ShowUpgrades(UpgradeData[] upgrades)
        {
            foreach (var upgrade in upgrades)
            {
                var upgradeCard = Instantiate(upgradeCardObject, transform);
                upgradeCard.transform.SetParent(transform);
                upgradeCard.GetComponent<UpgradeCard>().SetUpgrade(upgrade);
                upgradeCards.Add(upgradeCard);
            }     
        }
        
        public void SelectUpgrade(UpgradeData upgrade)
        {
            OnUpgradeSelected?.Invoke(upgrade);
            Debug.Log("UPGRADE SELECTED from controller " + upgrade.Title);
            foreach (var upgradeCard in upgradeCards)
            {
                Destroy(upgradeCard, 0.1f); 
            }
        }
    }
}
