using System;
using System.Collections.Generic;
using Player;
using UI.Upgrades;
using UnityEngine;
using Upgrades;

namespace Global
{
    public class UpgradeManager : MonoBehaviour
    {

        [Header("Settings")] 
        [SerializeField] private int upgradeCount = 4; 
        [Header("Debug")]
        [SerializeField] private List<UpgradeData> upgrades = new List<UpgradeData>();
        
        
        [Header("References")]
        [SerializeField] private UpgradeContainer upgradeContainer;

        #region Private Variables
        private LevelUpManager levelUpManager;
        private UIManager uiManager;
        private UpgradeSelectController upgradeSelectController; 
        private PlayerUpgradeManager playerUpgradeManager;
        #endregion

        private void Awake()
        {
            levelUpManager = GameManager.Instance.levelUpManager;
            uiManager = GameManager.Instance.uiManager; 
            upgradeSelectController = uiManager.upgradeSelectController; 
        }

        private void Start()
        {
            levelUpManager.OnLevelUp += OnLevelUp;
            upgradeSelectController.OnUpgradeSelected += OnUpgradeSelected;
            playerUpgradeManager = GameManager.Instance.playerManager.GetPlayer().GetComponent<PlayerUpgradeManager>(); 

        }

        private void OnUpgradeSelected(UpgradeData obj)
        {
            Debug.Log("UPGRADE SELECTED " + obj.Title); 
            playerUpgradeManager.AssignUpgrade(obj); 
            uiManager.CloseUpdateMenu(); 
            GameManager.Instance.ResumeGame(); 
        }

        private void OnLevelUp()
        { 
            if(levelUpManager.GetCurrentLevel() == 1) return;
            GameManager.Instance.PauseGame();
            uiManager.OpenUpdateMenu();  
            upgradeSelectController.ShowUpgrades(upgradeContainer.GetRandomUpgrades(upgradeCount));
        }
        
        
       
    }
}
