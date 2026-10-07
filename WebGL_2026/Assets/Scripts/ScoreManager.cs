using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public GameObject resultPanel;
    public TMP_Text scoreText;
    public TMP_Text bestText;

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void GameOver()
    {
        int best = PlayerPrefs.GetInt(ProjectConst.BEST_KEY, 0);

        if(score > best)
        {
            best = score;
            PlayerPrefs.SetInt(ProjectConst.BEST_KEY, best);
            PlayerPrefs.Save();
        }

        scoreText.text = "SCORE : " + score;
        bestText.text = "BEST : " + best;
        resultPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
