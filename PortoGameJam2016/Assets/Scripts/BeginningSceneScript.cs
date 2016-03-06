using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginningSceneScript : MonoBehaviour {

    public Text Text;

    // Use this for initialization
    void Start () {
        StartCoroutine(FadeStuff());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator FadeStuff()
    {
        yield return new WaitForSeconds(2f);
        float fadingSeconds = GetComponent<FadingScript>().BeginFade(1);
        yield return new WaitForSeconds(fadingSeconds);
        Text.text = "An Hypothetically Award Winning Game";
        fadingSeconds = GetComponent<FadingScript>().BeginFade(-1);
        yield return new WaitForSeconds(fadingSeconds);

        yield return new WaitForSeconds(1f);
        fadingSeconds = GetComponent<FadingScript>().BeginFade(1);
        yield return new WaitForSeconds(fadingSeconds);
        Text.text = "TWIRIO";
        
        fadingSeconds = GetComponent<FadingScript>().BeginFade(-1);
        yield return new WaitForSeconds(fadingSeconds);
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MainMenu");
    }
}
