using System;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Global
{
    public class LevelUpManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private float levelUpMultiplier = 1.2f;
        [SerializeField] public int droppableExperienceCount = 3;
        
        [Space]
        [Header("Start Settings")]
        [SerializeField] private float experienceToNextLevel = 10f; 
        [SerializeField] private int currentLevel = 0; 
         
        [Space]
        [Header("Runtime Settings")]
        [SerializeField] private float currentExperience = 0f;
        [SerializeField] private PlayerStats playerStats;
        public static LevelUpManager Instance { get; private set; }


        #region Events

        public event Action OnLevelUp;
        public event Action OnExperienceChange; 

        #endregion 
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
            playerStats = GameManager.Instance.playerManager.GetPlayerStats(); 
            LevelUp();
        }

        private void LevelUp()
        {
            currentLevel++;
            currentExperience = 0;
            experienceToNextLevel *= levelUpMultiplier;
            Debug.Log("Level Up!"); 
            OnLevelUp?.Invoke();
        }
        
        public int GetCurrentLevel()
        {
            return currentLevel;
        }
        
        public float GetExperienceToNextLevel()
        {
            return experienceToNextLevel;
        }
        
        public float GetCurrentExperience()
        {
            return currentExperience;
        }
        
        public void AddExperience()
        {
            currentExperience = Mathf.Min(currentExperience + playerStats.experienceMultiplier, experienceToNextLevel);
            OnExperienceChange?.Invoke();

            if (!(currentExperience >= experienceToNextLevel)) return;
            LevelUp();
            experienceToNextLevel *= playerStats.experienceMultiplier;
        }
        
        public float GetCollectDistance()
        {
            return playerStats.collectRange;
        } 
    }
}
