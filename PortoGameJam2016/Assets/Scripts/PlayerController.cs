using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerController : MonoBehaviour {

    public int CurrentScore = 0;
    public int lifes = 5;
    public Text ScoreText;
    public Text HealthText;

    bool attacking = false;

    void Update()
    {
        if (GameManager.Instance.CurrentMode == Mode.SideScroller)
        {
            transform.FindChild("Medieval Sword").transform.gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            PlayHitSound();
            transform.FindChild("Medieval Sword").transform.gameObject.SetActive(true);
            attacking = true;
        }
    }

    private void PlayHitSound()
    {
        gameObject.GetComponent<AudioSource>()
                        .Play();
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
        GetComponent<AudioSource>().Play();

        CurrentScore += score;
        ScoreText.text = CurrentScore.ToString();
    }

    public void OnEnemyKilled()
    {
        CurrentScore += 10;
        
    }

    public void attacked()
    {
        PlayHitSound();

        lifes -= 1;
        HealthText.text = lifes.ToString();
        Debug.Log("I was attacked!!");
        if (lifes == 0)
        {
            if (GameManager.Instance.CurrentMode == Mode.SideScroller)
                SceneManager.LoadScene("GameOverSideScroll");
            else
            {
                SceneManager.LoadScene("GameOverTopDown");
            }
        }
    }
}
