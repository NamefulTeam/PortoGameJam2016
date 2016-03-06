using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int CurrentScore = 0;
    public int lifes = 5;
    public Text ScoreText;

    public void AddScore(int score)
    {
        CurrentScore += score;
        ScoreText.text = CurrentScore.ToString();
    }

    public void OnEnemyKilled()
    {
        CurrentScore += 10;
        Debug.Log("Enemy Killed!!");
    }

    public void attacked()
    {
        lifes -= 1;
        Debug.Log("I was attacked!!");
    }
}
