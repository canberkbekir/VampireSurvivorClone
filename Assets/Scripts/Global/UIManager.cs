using System;
using UI.Upgrades;
using UnityEngine;

namespace Global
{
    public class UIManager : MonoBehaviour
    {
        
        [Header("UI Elements")]
        [SerializeField] private GameObject _pauseBackground;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _updateMenu;
        [SerializeField] private GameObject _gameOverMenu;
        
        [Space]
        [Header("Controllers")]
        [SerializeField] public UpgradeSelectController upgradeSelectController;
        
        [Header("References")]
        [SerializeField] private Input.InputObject _inputObject;
        [SerializeField] private GameManager _gameManager;

        private Player.Player _player;
        private void Awake()
        { 
            _inputObject.OnPauseEvent += PauseGame;
            _inputObject.OnResumeEvent += ResumeGame; 
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _player = _gameManager.playerManager.GetPlayer();
            _player.OnPlayerDeath += OnPlayerDeath;
        }

       

        #region Event Handlers

        private void PauseGame()
        {
            _inputObject.SetUI();
            _gameManager.PauseGame();
            OpenPauseMenu();
        }
        
        private void ResumeGame()
        {
            _inputObject.SetGameplay();
            _gameManager.ResumeGame();
            ClosePauseMenu();
        }
        
        private void OnPlayerDeath()
        {
            _gameManager.PauseGame();
            OpenGameOverMenu();
        }

        #endregion
        
        public void OpenPauseMenu()
        {
            _pauseBackground.SetActive(true);
            _pauseMenu.SetActive(true);
        }

        public void ClosePauseMenu()
        {
            _pauseBackground.SetActive(false);
            _pauseMenu.SetActive(false);
        }
        
        public void OpenUpdateMenu()
        {
            _pauseBackground.SetActive(true); 
            _updateMenu.SetActive(true);
        }
        
        public void CloseUpdateMenu()
        {
            _pauseBackground.SetActive(false);
            _updateMenu.SetActive(false);
        }
        
        public void OpenGameOverMenu()
        {
            _pauseBackground.SetActive(true); 
            _gameOverMenu.SetActive(true);
        }
        
    }
}
