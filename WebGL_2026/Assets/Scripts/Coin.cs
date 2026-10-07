using UnityEngine;

public class Coin : MonoBehaviour
{

    public int amount = 1;
    public Transform player;
    public ScoreManager scoreManager;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 0.6f)
        {
            scoreManager.AddScore(amount);
            float x = Random.Range(-2.5f, 2.5f);
            float y = Random.Range(-3.5f, 3.5f);
            transform.position = new Vector3(x, y, 0f);
        }
    }
}
