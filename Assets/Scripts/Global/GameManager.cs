using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Global
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        [Header("Managers")]
        [SerializeField] public PlayerManager playerManager;
        [SerializeField] public EnemySpawnerManager enemySpawnerManager;
        [SerializeField] public LevelUpManager levelUpManager;
        [SerializeField] public UIManager uiManager;
        
        [Space(20)]
        [Header("References")]
        [SerializeField] private Transform playerSpawnTransform;
        private void Awake()
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            }  
        }

        private void Start()
        {
            SpawnPlayer();

        }

        private void SpawnPlayer()
        { 
          playerManager.SetPlayer(Instantiate(playerManager.GetPlayerPrefab(), playerSpawnTransform.position, Quaternion.identity).GetComponent<Player.Player>());   
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

       
    }
}
