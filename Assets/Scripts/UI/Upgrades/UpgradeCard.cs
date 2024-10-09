using System;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace UI.Upgrades
{
    public class UpgradeCard : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI upgradeNameText;
        [SerializeField] private TMPro.TextMeshProUGUI upgradeDescriptionText;
        [SerializeField] private Image upgradeImage;
        private UpgradeData upgradeData;
        
        private void Start()
        {
            upgradeSelectController = transform.parent.GetComponent<UpgradeSelectController>();
        }

        [SerializeField] private UpgradeSelectController upgradeSelectController;

        public void SetUpgrade(UpgradeData upgrade)
        {
            if (upgrade == null)
            {
                Debug.LogError("UpgradeData is null!");
                return;
            }

            if (upgradeNameText == null)
            {
                Debug.LogError("upgradeNameText is not assigned!");
                return;
            }

            if (upgradeDescriptionText == null)
            {
                Debug.LogError("upgradeDescriptionText is not assigned!");
                return;
            }

            upgradeNameText.text = upgrade.Title;
            upgradeDescriptionText.text = upgrade.Description;
            upgradeData = upgrade;
        }
       
        public void SelectUpgrade()
        {
            if (upgradeData)
            {
                upgradeSelectController.SelectUpgrade(upgradeData);
            }
            else
            {
                Debug.LogError("Cannot select upgrade, upgradeData is null!");
            }
        }
    }
}

