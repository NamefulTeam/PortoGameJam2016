using UnityEngine;
using System.Collections;

public class CoinTopDownController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponentInParent<CoinController>().HandleCollision(other.gameObject);
    }
}
