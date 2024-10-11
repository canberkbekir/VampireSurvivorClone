using UnityEngine;

namespace UI
{
    public class HighScoreController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMPro.TextMeshProUGUI highScoreText;
        private void Start()
        {
            var highScore = PlayerPrefs.GetInt(Configs.GlobalProperties.HighScore.ToString());
            if (highScore > 0)
            {
                highScoreText.text =  $"{highScore} Lvl";
            }else
            {
                highScoreText.text = "-";
            }

        }
    }
}
