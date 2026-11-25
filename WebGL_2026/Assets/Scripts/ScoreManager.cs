using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
 
public class ScoreManager : MonoBehaviour
{
    public int score;
    public GameObject resultPanel;
    public TMP_Text scoreText;
    public TMP_Text bestText;
    public TMP_Text hudText;    
    static int playCount;
    static float lastAdTime = -999f;                     // 마지막 전면 광고를 띄운 시각
    public float adCooldown = 30f;                       // 전면 광고 사이의 최소 간격 (초)
 

    public void AddScore(int amount)
    {
        score += amount;
        hudText.text = score.ToString(); 
    }
 
    public void GameOver()
    {
        int best = PlayerPrefs.GetInt("BestScore", 0);
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("BestScore", best);
            PlayerPrefs.Save();
            ScoreSaver.Instance.Save(best);
        }
        scoreText.text = "SCORE " + score;
        bestText.text = "BEST " + best;
        resultPanel.SetActive(true);
        Time.timeScale = 0f;

    }
 
    public void Restart()                                // 실습 2 의 Restart 를 이렇게 교체
    {
        playCount++;
        bool enoughPlays = playCount >= 2;                                       // 첫 판 뒤에는 띄우지 않음
        bool enoughTime = Time.realtimeSinceStartup - lastAdTime > adCooldown;   // 마지막 광고 뒤 일정 시간
        if (enoughPlays && enoughTime && DummyAds.Instance.IsInterstitialReady())
        {
            lastAdTime = Time.realtimeSinceStartup;
            DummyAds.Instance.ShowInterstitial(Reload);
        }
        else Reload();
    }

    void Reload()                                        // 기존 Restart 의 내용을 여기로
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public GameObject doubleButton;                      // 결과 화면의 '광고 보고 점수 2배' 버튼
 
    public void WatchAdForDouble()                       // 버튼의 On Click
    {
        DummyAds.Instance.ShowRewarded(OnRewardClosed);
    }
 
    void OnRewardClosed(bool earned)                     // 광고가 닫히면 DummyAds 가 부름
    {
        if (!earned) return;                             // 중간에 닫았으면 보상 없음
        score *= 2;
        GameOver();                                      // 최고 점수 비교, 표시, 서버 저장을 다시
        doubleButton.SetActive(false);                   // 한 판에 한 번만
    }

}
