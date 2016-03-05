using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
    public int Worth = 5;
    Twistable twistable;
    float initialY;

    void Start()
    {
        twistable = GetComponent<Twistable>();

        initialY = transform.position.y;
        twistable.TransitionedToSideScrollerEvent += OnEnterSideScrollerMode;
    }

    public void HandleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<PlayerController>().AddScore(Worth);
            gameObject.SetActive(false);
        }
    }

    void OnEnterSideScrollerMode()
    {
        Debug.Log("Coin in side scroller mode");

        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
    }
}
