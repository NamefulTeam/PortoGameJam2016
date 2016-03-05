using UnityEngine;
using System.Collections;

public class PlayerTopDownBehaviourScript : MonoBehaviour {

    //settings for game
    public float speed = 10.0F;
    
    void Start () {

    }
	
	void FixedUpdate () {

        if (GameManager.Instance.CurrentMode == Mode.TopDown)
        {
            float translationX = Input.GetAxis("Horizontal");
            float translationY = Input.GetAxis("Vertical");

            GetComponent<Rigidbody>().AddForce(new Vector3(translationX, 0, 0) * speed);
        }
    }
}
