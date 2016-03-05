using UnityEngine;
using System.Collections;

public class CoinSideScrollerController : MonoBehaviour {
    
	void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponentInParent<CoinController>().HandleCollision(other.gameObject);
    }
}
