using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global
{
    public class DifficultyManager : MonoBehaviour
    { 
       [SerializeField] private List<int> _difficultyIncreaseTimes;
       [SerializeField] private float gameTime = 0.0f;
       [SerializeField] private int currentDifficultyLevel = 0;
       
       public event Action<int> OnDifficultyLevelChanged; 

       private void Start()
       {
              OnDifficultyLevelChanged?.Invoke(currentDifficultyLevel);
       } 
       
       private void FixedUpdate()
       {
              gameTime += Time.fixedDeltaTime;  
              
              if(gameTime >= _difficultyIncreaseTimes[currentDifficultyLevel])
              {
                     RaiseDifficulty();
              }
       }
       
       public TimeSpan GetCurrentTime()
       {
              return TimeSpan.FromSeconds(gameTime); 
       }
       
       public int GetCurrentDifficultyLevel()
       {
              return currentDifficultyLevel; 
       }
       
       private void RaiseDifficulty()
       {
              currentDifficultyLevel++; 
              OnDifficultyLevelChanged?.Invoke(currentDifficultyLevel);
       }
    }
}
