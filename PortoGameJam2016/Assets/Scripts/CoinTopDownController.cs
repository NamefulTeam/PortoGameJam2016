using UnityEngine;
using System.Collections;

public class CoinTopDownController : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var other = collision.other;
        gameObject.GetComponentInParent<CoinController>().HandleCollision(other.gameObject);
    }
}
