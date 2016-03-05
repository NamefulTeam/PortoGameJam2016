using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int CurrentScore = 0;
    public int lifes = 5;

    public void AddScore(int score)
    {
        CurrentScore += score;
    }

    public void OnEnemyKilled()
    {
        CurrentScore += 10;
    }
}
