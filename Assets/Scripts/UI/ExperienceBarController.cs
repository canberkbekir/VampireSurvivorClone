using DG.Tweening;
using Global;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExperienceBarController : MonoBehaviour
    {
        [SerializeField] private float levelUpAnimationPunch = 5f;
        
        [Header("References")]
        [SerializeField] private Slider _experienceBar;
        [SerializeField] private TextMeshProUGUI _levelText;
        
        private LevelUpManager _levelUpManager;
        
        private void Start()
        {  
            _levelUpManager = GameManager.Instance.levelUpManager; 
            if(_levelUpManager == null)
                Debug.LogError("LevelUpManager is null!"); 
            
            _levelUpManager.OnExperienceChange += OnExperienceChangeAction;
            _levelUpManager.OnLevelUp += OnLevelUpAction;
        }

        private void OnLevelUpAction()
        {
            if (_levelUpManager.GetCurrentLevel() != 1)
            {
                transform.DOPunchRotation(new Vector3(0, 0,levelUpAnimationPunch), 0.5f); 
            }
            _levelText.text = LevelText();
            _experienceBar.maxValue = _levelUpManager.GetExperienceToNextLevel();
            _experienceBar.value = _levelUpManager.GetCurrentExperience();
        }

        private void OnExperienceChangeAction()
        {
            _experienceBar.value = _levelUpManager.GetCurrentExperience();
        }
        
        private string LevelText()
        {
            return $@"Lvl. {_levelUpManager.GetCurrentLevel()}";
        }
    }
}
