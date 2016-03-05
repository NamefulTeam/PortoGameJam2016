using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitController : MonoBehaviour
{

    public void HandleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentBuildIndex + 1);

            gameObject.SetActive(false);
        }
    }
}
