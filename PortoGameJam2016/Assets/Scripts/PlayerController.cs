using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int CurrentScore = 0;
    public int lifes = 5;
    public Text ScoreText;

    bool attacking = false;

    void Update()
    {
        if (GameManager.Instance.CurrentMode == Mode.SideScroller)
        {
            transform.FindChild("Medieval Sword").transform.gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            transform.FindChild("Medieval Sword").transform.gameObject.SetActive(true);
            attacking = true;
            UnityEditor.AssetDatabase.Refresh();
        }
    }

    public bool isAttacking()
    {
        return attacking;
    }

    public void stoppedAttacking()
    {
        attacking = false;
    }

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
