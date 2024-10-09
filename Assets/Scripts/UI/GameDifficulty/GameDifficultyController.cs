using System;
using Global;
using UnityEngine;

namespace UI.GameDifficulty
{
    public class GameDifficultyController : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private TMPro.TextMeshProUGUI difficultyText;
        [SerializeField] private TMPro.TextMeshProUGUI difficultyLevelText;

        [SerializeField] private DifficultyManager difficultyManager; 

        private void Awake()
        {
            difficultyManager = GameManager.Instance.difficultyManager;
            
            difficultyManager.OnDifficultyLevelChanged += OnDifficultyLevelChanged;
        }

        private void OnDifficultyLevelChanged(int obj)
        {
            difficultyLevelText.text = $"x{obj+1}";
        }

        private void FixedUpdate()
        {
            var time = difficultyManager.GetCurrentTime();
            difficultyText.text = $"{time.Minutes:00} : {time.Seconds:00}";
        }
    }
}
