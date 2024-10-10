using System;
using Global;
using UnityEngine;

namespace UI
{
    public class GameOverController : MonoBehaviour
    {  
        [Header("References")] 
        [SerializeField] private GameManager _gameManager; 
        private void Awake()
        {
            _gameManager = GameManager.Instance; 
        } 
        
        public void RestartGame()
        {
            _gameManager.RestartGame();
        }
        
        public void QuitGame()
        {
            _gameManager.QuitGame();
        }
    }
}
