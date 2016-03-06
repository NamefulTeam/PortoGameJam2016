using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPlay()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
