using UnityEngine;
using System.Collections;

public class ExitTopDownController : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var other = collision.rigidbody;
        gameObject.GetComponentInParent<ExitController>().HandleCollision(other.gameObject);
    }
}
