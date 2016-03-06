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

    public void OnCollisionEnterChild()
    {
        CurrentScore += 10;
    }
}
