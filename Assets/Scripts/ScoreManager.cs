using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreAfterGameOver;
    private void Start()
    {
       
      
    }

    private void Update()
    {
        
    }

    public void setScore(int value)
    {
        score += value;
        textScore.text = "Score: " + score;
        textScoreAfterGameOver.text = "Score: " + score;
    }

    public void saveBestScore()
    {
      if(PlayerPrefs.HasKey("BestScore"))
        {
            if(PlayerPrefs.GetInt("BestScore")<score)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    public void clearScore()
    {
        score = 0;
        textScore.text = "Score: " + score;
        textScoreAfterGameOver.text = "Score: " + score;
    }

 
}
