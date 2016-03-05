using UnityEngine;
using System.Collections;

public class ExitSideScrollerController : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.GetComponentInParent<ExitController>().HandleCollision(other.gameObject);
    }
}
