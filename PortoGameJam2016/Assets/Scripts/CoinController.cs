using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
    public int Worth = 5;

    public void HandleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<PlayerController>().AddScore(Worth);
            gameObject.SetActive(false);
        }
    }
}
