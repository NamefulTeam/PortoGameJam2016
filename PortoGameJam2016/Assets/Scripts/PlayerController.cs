using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int CurrentScore = 0;

    public void AddScore(int score)
    {
        CurrentScore += score;
    }
}
